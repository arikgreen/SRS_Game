using System;
using System.Collections.Specialized;
using System.IO;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Markup;
using System.Xml;
using MVVM;
using Dictionary = MVVM.Dictionary;
using IMLM = Iml.Modeling;

namespace IML.ModelEdit
{
  /// <summary>
  /// Model widoku metamodelu
  /// </summary>
  [ContentProperty("Metatypes")]
  [Serializable]
  public class Metamodel: MetamodelingElement, IDictionaryProvider
  {
    /// <summary>
    /// Metamodel z IML
    /// </summary>
    public IMLM.Metamodel ImlMetamodel { get; protected set; }

    /// <summary>
    /// Kolekcja typów składowych metamodelu
    /// </summary>
    public Metatypes Metatypes { get; protected set; }

    /// <summary>
    /// Kolekcja typów nie posiadających typu bazowego w tym modelu
    /// </summary>
    public ViewModelsFilteredCollection<Metatype> RootTypes { get; protected set; }

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Metamodel()
    {
      ImlMetamodel = new IMLM.Metamodel();
      Metatypes = new Metatypes(this);
      Metatypes.CollectionChanged += MetatypesCollectionChanged;
      RootTypes = new ViewModelsFilteredCollection<Metatype> { Source = Metatypes };
      RootTypes.Filter = RootTypesFilter;
    }

    /// <summary>
    /// Filtr sprawdzający, czy element metamodelu należy do kolekcji <see cref="RootTypes"/>
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void RootTypes_Filter (object sender, FilterEventArgs args)
    {
      Metaclass item = args.Item as Metaclass;
      args.Accepted = (item.BaseType == null || !(item.BaseType.Target is Metatype)
         || (item.BaseType.Target as Metatype).Metamodel != this);
    }

    private bool RootTypesFilter(object obj)
    {
      Metaclass item = obj as Metaclass;
      if (item != null)
        return (item.BaseType == null || !(item.BaseType.Target is Metatype)
         || (item.BaseType.Target as Metatype).Metamodel != this);
      else
        return true;
    }

    /// <summary>
    /// Metamodel jest sam dla siebie źródłem zasobów słownikowych
    /// </summary>
    protected override IDictionaryProvider DictionaryProvider
    {
      get { return this; }
    }

    /// <summary>
    /// Nazwa główna łańcucha tekstowego w zasobach
    /// </summary>
    protected override string ResourceName
    {
      get
      {
        return Namespace;
      }
    }

    /// <summary>
    /// Przy zmianie kolekcji VM jest zmieniana kolekcja IML
    /// </summary>
    public void MetatypesCollectionChanged(object sender, NotifyCollectionChangedEventArgs args)
    {
      if (ImlMetamodel == null)
        return;
      switch (args.Action)
      {
        case NotifyCollectionChangedAction.Add:
          foreach (Metatype item in args.NewItems)
            ImlMetamodel.Metatypes.Add(item.ImlMetatype);
          break;
        case NotifyCollectionChangedAction.Remove:
          foreach (Metatype item in args.OldItems)
            ImlMetamodel.Metatypes.Remove(item.ImlMetatype);
          break;
        case NotifyCollectionChangedAction.Reset:
          break;
      }
    }


    /// <summary>
    /// Metoda ładowania danych
    /// </summary>
    public void Load ()
    {
      string filename = Namespace +".dll";
      Assembly = Assembly.LoadFile(Path.Combine(Configurator.ModelsAssemblyPath, filename));
      LoadFrom(Assembly);

    }

    /// <summary>
    /// Ładowanie metamodelu z biblioteki
    /// </summary>
    private void LoadFrom (Assembly assembly)
    {
      string metamodelTypeName = Namespace + "." + Name + "Model";
      Type metamodelType = assembly.GetType(metamodelTypeName);
      if (metamodelType != null)
      {
        Namespace = metamodelType.Namespace;
        Metatypes.Clear();
        Metatypes.LoadFrom(metamodelType);
      }
      LoadResources();
      ResolveReferences();
    }

    /// <summary>
    /// Zaimplementowana metoda zapamiętywania danych
    /// </summary>
    protected override void OnStore ()
    {
      StoreDefinition();
      StoreResources();
      if (NeedsRecompilation)
      {
        CodeBuilder.Compile(this);
        NeedsRecompilation = false;
      }
    }

    /// <summary>
    /// Zapisanie definicji metamodelu w pliku XAML
    /// </summary>
    public void StoreDefinition ()
    {
      string filename = Path.Combine(Configurator.ConfigPath, GetDefinitionFileName());
      using (TextWriter aWriter = new StreamWriter(filename))
      {
        using (XmlWriter xWriter = XmlWriter.Create(aWriter, new XmlWriterSettings { Indent = true, OmitXmlDeclaration = false }))
        {
          XamlWriter.Save(ImlMetamodel, xWriter);
        }
      }
    }

    /// <summary>
    /// Zapisanie zasobów tekstowych metamodelu w pliku RESX powiązanym z biblioteką
    /// </summary>
    public override void StoreResources ()
    {
      string filename = Path.Combine(Configurator.ConfigPath, GetResourceFileName());
      filename = Configurator.CurrentCultureFilename(filename);
      Dictionary dictionary;
      if (!Configurator.MetamodelsResources.TryGetValue(filename, out dictionary))
      {
        dictionary = new Dictionary();
        Configurator.MetamodelsResources.Add(filename, dictionary);
      }

      base.StoreResources();
      dictionary.SaveToResxFile(filename, false);
    }

    /// <summary>
    /// Pobranie słownika zasobów tekstowych metamodelu
    /// </summary>
    /// <returns></returns>
    public Dictionary GetXmlDocsDictionary ()
    {
      Dictionary resources = null;
      string filename = Path.Combine(Configurator.ConfigPath, GetXmlDocsFileName());
      if (!Configurator.MetamodelsResources.TryGetValue(filename, out resources))
      {
        if (File.Exists(filename))
        {
          resources = new Dictionary();
          resources.LoadFromXmlDocsFile(filename, false);
          Configurator.MetamodelsResources.Add(filename, resources);
        }
      }
      return resources;
    }

    /// <summary>
    /// Pobranie słownika zasobów tekstowych metamodelu
    /// </summary>
    /// <returns></returns>
    public Dictionary GetStringResourceDictionary ()
    {
      Dictionary resources = null;
      string filename = Path.Combine(Configurator.ConfigPath, GetResourceFileName());
      string tempFilename = Configurator.CurrentCultureFilename(filename);
      if (!(Configurator.MetamodelsResources.TryGetValue(tempFilename, out resources)
         || Configurator.MetamodelsResources.TryGetValue(filename, out resources)))
      {
        if (File.Exists(tempFilename))
          filename = tempFilename;
        if (File.Exists(filename))
        {
          resources = new Dictionary();
          resources.LoadFromResxFile(filename, false);
          Configurator.MetamodelsResources.Add(filename, resources);
        }
      }
      return resources;
    }

    /// <summary>
    /// Podaje nazwę pliku z zasobami tekstowymi dotyczącymi nazw prezentacyjnych i opisów
    /// </summary>
    /// <returns></returns>
    protected string GetDefinitionFileName ()
    {
      string filename = Namespace;
      filename += ".xaml";
      return filename;
    }

    /// <summary>
    /// Podaje nazwę pliku z zasobami tekstowymi dotyczącymi nazw prezentacyjnych i opisów
    /// </summary>
    /// <returns></returns>
    protected string GetXmlDocsFileName ()
    {
      string filename = Namespace;
      filename += ".xml";
      return filename;
    }

    /// <summary>
    /// Podaje nazwę pliku z zasobami tekstowymi dotyczącymi nazw prezentacyjnych i opisów
    /// </summary>
    /// <returns></returns>
    protected string GetResourceFileName ()
    {
      string filename = Namespace;
      filename += ".resx";
      return filename;
    }

    /// <summary>
    /// Nazwa własna metamodelu
    /// </summary>
    public string Namespace
    {
      get { return fNamespace; }
      set
      {
        if (fNamespace != value)
        {
          fNamespace = value;
          NotifyPropertyChanged("Namespace");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące nazwę własną metamodelu
    /// </summary>
    protected string fNamespace;

    /// <summary>
    /// Biblioteka reprezentująca metamodel
    /// </summary>
    public Assembly Assembly 
    {
      get { return fAssembly; }
      set
      {
        if (fAssembly!=value)
        {
          fAssembly = value;
          NotifyPropertyChanged("Assembly");
          NotifyPropertyChanged("AssemblyName");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące bibliotekę
    /// </summary>
    protected Assembly fAssembly;

    /// <summary>
    /// Nazwa biblioteki reprezentującej metamodel
    /// </summary>
    public string AssemblyName
    {
      get 
      {
        if (Assembly != null)
        {
          string result = Assembly.GetName().ToString();
          if (!String.IsNullOrEmpty(result))
          {
            string[] ss = result.Split(',');
            if (ss.Length > 0)
              result = ss[0];
          }
          return result;
        }
        return fAssemblyName; 
      }
      set
      {
        if (AssemblyName != value)
        {
          fAssemblyName = value;
          NotifyPropertyChanged("AssemblyName");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące bibliotekę
    /// </summary>
    protected string fAssemblyName;

    /// <summary>
    /// Czy metamodel jest chroniony przed zmianą
    /// </summary>
    public bool IsProtected
    {
      get { return fIsProtected; }
      set
      {
        if (fIsProtected != value)
        {
          fIsProtected = value;
          NotifyPropertyChanged("IsProtected");
        }
      }
    }
    /// <summary>
    /// Pole przechowująca info czy metamodel jest chroniony
    /// </summary>
    protected bool fIsProtected;

    /// <summary>
    /// Zaimplementowana metoda kopiowania właściwości do obiektu innego obiektu
    /// </summary>    
    /// <param name="other">obiekt docelowy</param>
    /// <param name="compareLocalizedProperties">czy kopiować dane lokalizowane</param>
    public override void CopyTo(object other, bool copyLocalizedProperties)
    {
      if (other is Metamodel)
        CopyTo((Metamodel)other, copyLocalizedProperties);
      else if (other is IMLM.Metamodel)
        CopyTo((IMLM.Metamodel)other);
    }

    /// <summary>
    /// Kopiowanie elementu tej samej klasy
    /// </summary>
    /// <param name="other">inna instancja tej samej klasy</param>
    /// <param name="compareLocalizedProperties">czy kopiować dane lokalizowane</param>
    public void CopyTo(Metamodel other, bool copyLocalizedProperties)
    {
      other.Name = this.Name;
      other.Namespace = this.Namespace;
      other.Assembly = this.Assembly;
      if (!copyLocalizedProperties)
        return;
      other.DisplayName = this.DisplayName;
      other.Description = this.Description;
    }

    /// <summary>
    /// Kopiowanie do elementu IML
    /// </summary>
    /// <param name="target"></param>
    public void CopyTo (IMLM.Metamodel target)
    {
      target.Name = this.Name;
      target.Metatypes.Clear();
      Metatypes.CopyTo(target.Metatypes);
    }

    /// <summary>
    /// Zaimplementowana metoda porównania właściwości
    /// </summary>
    /// <param name="other"></param>
    /// <param name="compareLocalizedProperties">czy porównywać dane lokalizowane</param>
    public override bool EqualsTo(object other, bool compareLocalizedProperties)
    {
      if (other is Metamodel)
        return EqualsTo((Metamodel)other, compareLocalizedProperties);
      return this!=other;
    }

    /// <summary>
    /// Porównanie właściwości instancji tej samej klasy
    /// </summary>
    /// <param name="other"></param>
    /// <param name="compareLocalizedProperties">czy porównywać dane lokalizowane</param>
    public bool EqualsTo (Metamodel other, bool compareLocalizedProperties)
    {
      bool result =
        other.Name == this.Name &&
        other.Namespace == this.Namespace &&
        other.Assembly == this.Assembly;
      if (result && compareLocalizedProperties)
        result =
        other.DisplayName == this.DisplayName &&
        other.Description == this.Description;
      return result;
    }

    /// <summary>
    /// Porównanie głównych właściwości instancji tej samej klasy
    /// </summary>
    /// <param name="other"></param>
    public bool CoreEqualsTo(Metamodel other)
    {
      return
        other.Name == this.Name &&
        other.Namespace == this.Namespace &&
        other.Assembly == this.Assembly;
    }

    /// <summary>
    /// Rozwiązanie referencji - dotyczy typów składowych
    /// </summary>
    public override void ResolveReferences()
    {
      if (Metatypes != null)
        foreach (Metatype item in Metatypes)
          item.ResolveReferences();
    }

    /// <summary>
    /// Czy wartość wymaga rekompilacji
    /// </summary>
    public override bool NeedsCompilation()
    {
       return !CoreEqualsTo(this.OriginalInstance as Metamodel);
    }

    /// <summary>
    /// Czy metamodel wymaga rekompilacji
    /// </summary>
    public bool NeedsRecompilation
    {
      get { return fNeedsRecompilation; }
      set
      {
        if (fNeedsRecompilation!=value)
        {
          fNeedsRecompilation = value;
          NotifyPropertyChanged("NeedsRecompilation");
        }
      }
    }
    private bool fNeedsRecompilation;
  }

}

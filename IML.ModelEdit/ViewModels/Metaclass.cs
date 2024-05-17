using MVVM;
using MyLib.Controls;
using System;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Data;
using System.Windows.Markup;
using IMLM = Iml.Modeling;


namespace IML.ModelEdit
{
  /// <summary>
  /// Model widoku metaklasy
  /// </summary>
  [ContentProperty("Properties")]
  public partial class Metaclass : Metatype
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Metaclass()
    {
      Properties = new ClassProperties(this);
      Properties.CollectionChanged += Properties_CollectionChanged;
      PropertyChanged += Metaclass_PropertyChanged;
    }

    /// <summary>
    /// Przy zmianie właściwości <see cref="Metamodel"/> tworzona jest kolekcja klas potomnych.
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    protected void Metaclass_PropertyChanged (object sender, PropertyChangedEventArgs args)
    {
      if (args.PropertyName == "Metamodel" && Metamodel != null)
      {
        Metatypes metatypes = Metamodel.Metatypes;
        Subclasses = new Subclasses(this);//ViewModelsFilteredEditableList<Metatype> { Source = metatypes };
      }
    }

    /// <summary>
    /// Metaklasa z IML
    /// </summary>
    public IMLM.Class ImlClass 
    {
      get { return base.ImlMetatype as IMLM.Class; }
      protected set { base.ImlMetatype = value; }
    }

    /// <summary>
    /// Ładowanie metaklasy z typu C#
    /// </summary>
    /// <param name="type"></param>
    public override void LoadFrom (Type type)
    {
      this.ImlMetatype = new IMLM.Class();
      this.Name = type.Name;
      this.Type = type;
      this.IsAbstract = type.GetCustomAttribute(typeof(IMLM.IsAbstractAttribute),false) != null;
      Properties.LoadFrom(type);
      if (Metamodel != null)
      {
        LoadResourcesFrom(Metamodel.GetXmlDocsDictionary());
      }
    }

    /// <summary>
    /// Czy metaklasa jest abstrakcyjna
    /// </summary>
    [DataProperty(LabelPath="AbstractClass", Protected=true)]
    public bool IsAbstract
    {
      get { return fIsAbstract; }
      set
      {
        if (fIsAbstract != value)
        {
          fIsAbstract = value;
          if (ImlClass != null)
            ImlClass.IsAbstract = value;
          NotifyPropertyChanged("IsAbstract");
        }
      }
    }
    /// <summary>
    /// Pole przechowująca info czy metaklasa jest abstrakcyjna
    /// </summary>
    protected bool fIsAbstract;

    /// <summary>
    /// Właściwości danej metaklasy
    /// </summary>
    public ClassProperties Properties { get; protected set;}

    /// <summary>
    /// Przy zmianie kolekcji modeli widoku właściwości jest zmieniana kolekcja IML.
    /// Kolekcja modeli widoku właściwości zawiera wszystkie - również odziedziczone właściwości,
    /// ale kolekcja właściwości IML w klasie zawiera tylko te nie dziedziczone.
    /// </summary>
    public void Properties_CollectionChanged (object sender, NotifyCollectionChangedEventArgs args)
    {
      IMLM.Class imlClass = ImlClass;
      if (imlClass == null)
        return;
      switch (args.Action)
      {
        case NotifyCollectionChangedAction.Add:
          foreach (ClassProperty item in args.NewItems)
          { 
            if (!item.IsInherited)
              imlClass.Properties.Add(item.ImlProperty);
          }
          break;
        case NotifyCollectionChangedAction.Remove:
          foreach (ClassProperty item in args.OldItems)
          {
            if (!item.IsInherited)
              imlClass.Properties.Remove(item.ImlProperty);
          }
          break;
        case NotifyCollectionChangedAction.Reset:
          break;
      }
    }

    /// <summary>
    /// Kolekcja klas potomnych
    /// </summary>
    public Subclasses Subclasses { get; protected set; }

    /// <summary>
    /// Zaimplementowana metoda kopiowania właściwości
    /// </summary>    
    /// <param name="other">inny obiekt do porównania</param>
    /// <param name="copyLocalizedProperties">czy porównywać lokalizowane dane</param>
    public override void CopyTo (object other, bool copyLocalizedProperties)
    {
      if (other is Metaclass)
        CopyTo((Metaclass)other, copyLocalizedProperties);
      else if (other is IMLM.Class)
        CopyTo((IMLM.Class)other);
    }

    /// <summary>
    /// Kopiowanie elementu tej samej klasy
    /// </summary>
    /// <param name="other">inna instancja tej samej klasy</param>
    /// <param name="copyLocalizedProperties">czy porównywać lokalizowane dane</param>
    public void CopyTo(Metaclass other, bool copyLocalizedProperties)
    {
      bool needsRefresh = (other == this.OriginalInstance) && other.BaseType != this.BaseType;
      base.CopyTo(other, copyLocalizedProperties);
      other.BaseType = this.BaseType;
      other.IsAbstract = this.IsAbstract;
      if (needsRefresh)
        Metamodel.RootTypes.Refresh();
      if (other == this.OriginalInstance)
        Metamodel.Store();
    }

    /// <summary>
    /// Kopiowanie elementu do metaklasy IML
    /// </summary>
    /// <param name="target"></param>
    public void CopyTo (IMLM.Class target)
    {
      target.Name = this.Name;
      target.DerivedFrom = this.BaseType!=null ? this.BaseType.TargetName : null;
      target.IsAbstract = this.IsAbstract;
    }

    /// <summary>
    /// Zaimplementowana metoda porównania właściwości
    /// </summary>
    /// <param name="other">obiekt docelowy</param>
    /// <param name="compareLocalizedProperties">czy porównywać lokalizowane dane</param>
    public override bool EqualsTo (object other, bool compareLocalizedProperties)
    {
      if (other is Metaclass)
        return EqualsTo((Metaclass)other, compareLocalizedProperties);
      return this != other;
    }

    /// <summary>
    /// Porównanie właściwości instancji tej samej klasy
    /// </summary>
    /// <param name="other">inna instancja tej samej klasy</param>
    /// <param name="compareLocalizedProperties">czy porównywać lokalizowane dane</param>
    public bool EqualsTo(Metaclass other, bool compareLocalizedProperties)
    {
      return
        base.EqualsTo(other, compareLocalizedProperties) &&
        other.BaseType == this.BaseType && 
        other.IsAbstract == this.IsAbstract;
    }

    /// <summary>
    /// Czy wartość wymaga rekompilacji metamodelu
    /// </summary>
    public new bool NeedsCompilation
    {
      get
      {
        return !EqualsTo(this.OriginalInstance as Metaclass, false);
      }
    }

    ///// <summary>
    ///// Odświeżanie zasobów
    ///// </summary>
    //public override void LoadResources ()
    //{
    //  base.LoadResources();
    //  if (Properties != null)
    //    Properties.RefreshResources();
    //}

    #region BaseType
    /// <summary>
    /// Typ bazowy - na podstawie którego został zdefiniowany dany typ
    /// </summary>
    [DataProperty(Protected=true, ControlType=ControlType.ComboBox)] 
    [Binding("ItemsSource", Path="PossibleBaseTypes", Mode=BindingMode.OneWay)]
    [Binding("ItemTemplate", Source="DisplayNameTemplate")]
    [Binding("DefaultValue", Path="DefaultBaseMetaclass", Source="MetamodelingResources")]
    public virtual TypeReference BaseType
    {
      get { return fBaseType; }
      set
      {
        if (fBaseType != value)
        {
          fBaseType = value;
          NotifyPropertyChanged("BaseType");
        }
      }
    }
    /// <summary>
    /// Pole przechowująca referencję do klasy bazowej
    /// </summary>
    protected TypeReference fBaseType;

    /// <summary>
    /// Ta właściwość podaje dozwolone typy bazowe
    /// </summary>
    public TypeReferences PossibleBaseTypes
    {
      get
      {
        fPossibleBaseTypes = new TypeReferences(this);
        if (Metamodel != null)
        {
          if (Metamodel.Collection is Metamodels)
          {
            Metatype baseType = (Metamodel.Collection as Metamodels).GetBaseMetaclass();
            if (baseType != null)
              fPossibleBaseTypes.Add(new TypeReference(baseType));
          }
          foreach (Metatype item in Metamodel.RootTypes)
          {
            if (item is Metaclass && !item.EqualsTo(this))
            {
              fPossibleBaseTypes.Add(new TypeReference(item));
              (item as Metaclass).GetSubtypes(fPossibleBaseTypes, this);
            }
          }
        }
        return fPossibleBaseTypes;
      }
    }
    protected TypeReferences fPossibleBaseTypes;

    /// <summary>
    /// Podaje listę podtypów tak długo, aż nie napotka elementu <paramref name="except"/>
    /// </summary>
    /// <param name="list">lista, do której wpisywane są podklasy</param>
    /// <param name="except">element pomijany</param>
    public void GetSubtypes (TypeReferences list, Metatype except)
    {
      if (Subclasses!=null)
      {
        foreach (Metatype item in Subclasses)
        {
          if (except==null || !item.EqualsTo(except))
          {
            list.Add(new TypeReference(item));
            if (item is Metaclass)
              (item as Metaclass).GetSubtypes(list, except);
          }
        }
      }
    }

    /// <summary>
    /// Rozwiązanie referencji do typu bazowego
    /// </summary>
    /// <param name="type"></param>
    protected void ResolveBaseTypeReference(Type type)
    {
      Metaclass metatype = null;
      if (type==null)
        metatype = (from item in this.PossibleBaseTypes
                    select item.Target as Metatype).FirstOrDefault() as Metaclass;
      else
        metatype = (from item in this.PossibleBaseTypes
         where (item.Target as Metatype).Type == type
         select item.Target as Metatype).FirstOrDefault() as Metaclass;
      if (metatype == null)
        this.BaseType = new TypeReference(type);
      else
        this.BaseType = new TypeReference(metatype);
    }
    #endregion

    /// <summary>
    /// Rozwiązanie referencji - tu dotyczy właściwości
    /// </summary>
    public override void ResolveReferences()
    {
      if (BaseType != null && BaseType.Target == null && BaseType.TargetType != null)
        ResolveBaseTypeReference(BaseType.TargetType);
      else if (Type!=null && Type.BaseType!=null)
        ResolveBaseTypeReference(Type.BaseType);
      else 
        ResolveBaseTypeReference(null);
      if (Properties != null)
        foreach (ClassProperty item in Properties)
          item.ResolveReferences();
    }

  }
}

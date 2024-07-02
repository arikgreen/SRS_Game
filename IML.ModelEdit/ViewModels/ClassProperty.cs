using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IMLM = Iml.Modeling;
using MVVM;
using MyLib.Controls;
using System.Windows.Data;

namespace IML.ModelEdit
{
  /// <summary>
  /// Model widoku metaklasy
  /// </summary>
  [Action("NewClassProperty",
    LabelPath = "NewClassProperty",
    CommandSource = typeof(BaseViewModelListControl),
    CommandName = "NewItemCommand", 
    CommandParameter = typeof(ClassProperty),
    Order = 1,
    Protected = true)]

  [Action("EditClassProperty",
    LabelPath = "EditClassProperty",
    CommandSource = typeof(BaseViewModelListControl),
    CommandName = "EditItemCommand",
    Order = 2)]
   
  [Action("DeleteClassProperty",
    LabelPath="DeleteClassProperty",
    CommandSource = typeof(BaseViewModelListControl),
    CommandName = "DeleteItemCommand",
    Order =3, 
    Protected = true)]

  public partial class ClassProperty : MetamodelingElement
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ClassProperty ()
    {
      ImlProperty = new IMLM.Property();
      PropertyChanged += ClassProperty_PropertyChanged;
    }

    /// <summary>
    /// Powiązanie sygnatury z nazwą i typem
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    void ClassProperty_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs args)
    {
      if (ImlProperty != null)
        CopyTo(ImlProperty);
      if (args.PropertyName == "Name" || args.PropertyName=="Type")
        NotifyPropertyChanged("Signature");
    }

    /// <summary>
    /// Metawłaściwość z IML
    /// </summary>
    public IMLM.Property ImlProperty { get; protected set; }

    /// <summary>
    /// Ładowanie danych z informacji o właściwości C#
    /// </summary>
    /// <param name="property"></param>
    public void LoadFrom (PropertyInfo property)
    {
      this.ImlProperty = new IMLM.Property();
      this.Name = property.Name;
      Type type = property.PropertyType;
      if (type==typeof(Iml.Foundation.ReferenceList))
      {
        type = typeof(Iml.Modeling.ModelElement);
        this.IsList = true;
      }
      else
      if (type!=typeof(string)  && type.GetInterface("IEnumerable")!=null)
      {
        Type iEnumerable = type.GetInterface("IEnumerable`1");
        if (iEnumerable.GenericTypeArguments!=null && iEnumerable.GenericTypeArguments.Length>=1)
        {
          type = iEnumerable.GenericTypeArguments[0];
          if (type == typeof(Iml.Foundation.Reference))
          {
            IEnumerable<Attribute> customAttributes = type.GetCustomAttributes();
          }
        }
        this.IsList = true;
      }
      ResolveTypeReference(type);
      LoadResources();
    }

    /// <summary>
    /// Rozwiązanie referencji do typu właściwości
    /// </summary>
    /// <param name="type">typ właściwości</param>
    protected void ResolveTypeReference(Type type)
    {
      Metatype metatype = (from item in this.PossibleDataTypes
                           where (item.Target as Metatype).Type == type
                           select item.Target as Metatype).FirstOrDefault();
      if (metatype == null)
        this.Type = new TypeReference(type);
      else
        this.Type = new TypeReference(metatype);
    }

    /// <summary>
    /// Rozwiązanie referencji - tu dotyczy referencji do typu właściwości
    /// </summary>
    public override void ResolveReferences()
    {
      if (Type==null)
        ResolveTypeReference(typeof(string));
      else  if (Type != null && Type.Target == null && Type.TargetType != null)
        ResolveTypeReference(Type.TargetType);
    }

    /// <summary>
    /// Sygnatura składająca się z nazwy i typu
    /// </summary>
    public override string Signature
    {
      get 
      {
        string result = Name;
        if (Type!=null)
        {
          result += ": ";
          if (IsList)
            result += String.Format("List<{0}>", Type.TargetName);
          else
            result += Type.TargetName;       
        }
        return result;
      }
    }

    /// <summary>
    /// Nazwa ikony
    /// </summary>
    public override string IconName
    {
      get
      {
        return "Property";
      }
    }

    /// <summary>
    /// Typ wartości
    /// </summary>
    [DataProperty(LabelPath="PropertyType", Protected = true, ControlType = ControlType.ComboBox, Order = 2)]
    //[Binding("ItemsSource", Path = "PossibleDataTypes", Mode = BindingMode.OneWay)]
    [Binding("ItemTemplate", Source = "DisplayNameTemplate")]
    public TypeReference Type
    {
      get { return fType; }
      set
      {
        if (fType != value)
        {
          fType = value;
          if (ImlProperty != null && fType!=null)
          {
            if (IsList)
              ImlProperty.Type = String.Format("List<{0}>",fType.TargetName);
            else
              ImlProperty.Type = fType.TargetName;
          }
          NotifyPropertyChanged("Type");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące typ wartości
    /// </summary>
    protected TypeReference fType;

    /// <summary>
    /// Znacznik listy - właściwość daje dostęp do listy elementów podanego typu
    /// </summary>
    [DataProperty(LabelPath = "MultiProperty", Protected = true, Order=1)]
    public bool IsList
    {
      get { return fIsList; }
      set
      {
        if (fIsList != value)
        {
          fIsList = value;
          if (ImlProperty != null && fType != null)
          {
            if (IsList)
              ImlProperty.Type = String.Format("List<{0}>", fType.TargetName);
            else
              ImlProperty.Type = fType.TargetName;
          }
          NotifyPropertyChanged("IsList");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące znacznik listy
    /// </summary>
    protected bool fIsList;

    /// <summary>
    /// Metaklasa, do której należy ta właściwość
    /// </summary>
    public Metaclass Metaclass
    {
      get
      {
        return fMetaclass;
      }
      set
      {
        if (fMetaclass != value)
        {
          fMetaclass = value;
          NotifyPropertyChanged("Metaclass");
        }
      }
    }
    private Metaclass fMetaclass;

    /// <summary>
    /// Dostęp do metamodelu klasy macierzystej właściwości
    /// </summary>
    public Metamodel Metamodel
    {
      get
      {
        if (Metaclass != null)
          return Metaclass.Metamodel;
        return null;
      }
    }

    /// <summary>
    /// Dostęp do metamodelu dającego słownik zasobów
    /// </summary>
    protected override IDictionaryProvider DictionaryProvider
    {
      get { return Metamodel; }
    }

    /// <summary>
    /// Nazwa główna łańcucha tekstowego w zasobach
    /// </summary>
    protected override string ResourceName
    {
      get 
      {
        if (Metaclass != null)
          return Metaclass.Name + "." + Name;
        return null;
      }
    }

    /// <summary>
    /// Nazwa typu, który zadeklarował tę właściwość
    /// </summary>
    public string DeclaringType
    {
      get
      {
        return fDeclaringType;
      }
      set
      {
        if (fDeclaringType != value)
        {
          fDeclaringType = value;
          NotifyPropertyChanged("DeclaringType");
        }
      }
    }
    private string fDeclaringType;

    /// <summary>
    /// Czy właściwość jest odziedziczona
    /// </summary>
    public bool IsInherited
    {
      get
      {
        if (DeclaringType != null && Metaclass != null)
          return DeclaringType != Metaclass.Name;
        else
          return false;
      }
    }

    /// <summary>
    /// Zaimplementowana metoda kopiowania właściwości
    /// </summary>   
    /// <param name="other">obiekt docelowy</param>
    /// <param name="copyLocalizedProperties">czy kopiować dane lokalizowane</param>
    public override void CopyTo (object other, bool copyLocalizedProperties)
    {
      if (other is ClassProperty)
        CopyTo((ClassProperty)other, copyLocalizedProperties);
      else if (other is IMLM.Property)
        CopyTo((IMLM.Property)other);
    }

    /// <summary>
    /// Kopiowanie elementu tej samej klasy
    /// </summary>
    /// <param name="other">inna instancja tej samej klasy</param>
    /// <param name="copyLocalizedProperties">czy kopiować dane lokalizowane</param>
    public void CopyTo (ClassProperty other, bool copyLocalizedProperties)
    {
      other.Name = this.Name;
      other.Type = this.Type;
      if (!copyLocalizedProperties)
        return;
      other.DisplayName = this.DisplayName;
      other.Description = this.Description;
    }

    /// <summary>
    /// Kopiowanie elementu do IML
    /// </summary>
    /// <param name="target"></param>
    public void CopyTo (IMLM.Property target)
    {
      target.Name = this.Name;
      target.Type = this.Type!=null ? this.Type.TargetName : null;
    }

    /// <summary>
    /// Zaimplementowana metoda porównania właściwości z innym obiektem
    /// </summary>
    /// <param name="other">obiekt docelowy</param>
    /// <param name="compareLocalizedProperties">czy porównywać lokalizowane dane</param>
    public override bool EqualsTo(object other, bool compareLocalizedProperties)
    {
      if (other is ClassProperty)
        return EqualsTo((ClassProperty)other, compareLocalizedProperties);
      return this != other;
    }

    /// <summary>
    /// Porównanie właściwości instancji tej samej klasy
    /// </summary>
    /// <param name="other">inna instancja tej samej klasy</param>
    /// <param name="compareLocalizedProperties">czy porównywać lokalizowane dane</param>
    public bool EqualsTo (ClassProperty other, bool compareLocalizedProperties)
    {
      bool result =
        other.Name == this.Name &&
        other.Type == this.Type;
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
    public bool CoreEqualsTo(ClassProperty other)
    {
      return
        other.Name == this.Name &&
        other.Type == this.Type;
    }

    /// <summary>
    /// Czy definicja właściwości jest chroniona przed zmianą.
    /// </summary>
    public bool IsProtected
    {
      get
      {
        if (IsInherited)
          return true;
        if (Metamodel != null)
          return Metamodel.IsProtected;
        else
          return false;
      }
    }

    /// <summary>
    /// Czy sygnatura ma być wyświetlona kursywą
    /// </summary>
    public override bool NeedsItalic
    {
      get
      {
        return IsInherited;
      }
    }

    /// <summary>
    /// Czy wartość wymaga rekompilacji metamodelu
    /// </summary>
    public override bool NeedsCompilation()
    {
      return !CoreEqualsTo(this.OriginalInstance as ClassProperty);
    }

    /// <summary>
    /// Podaje listę referencji do dozwolonych typów właściwości
    /// </summary>
    public TypeReferences PossibleDataTypes
    {
      get
      {
        fPossibleTypes = new TypeReferences(this);
        foreach (Metatype type in SystemMetatypes)
          fPossibleTypes.Add(new TypeReference(type));
        if (Metamodel != null)
        {
          foreach (Metatype item in Metamodel.RootTypes)
          {
            fPossibleTypes.Add(new TypeReference(item));
            if (item is Metaclass)
              (item as Metaclass).GetSubtypes(fPossibleTypes, null);
          }
        }
        return fPossibleTypes;
      }
    }
    protected TypeReferences fPossibleTypes;


    public static Metatypes SystemMetatypes = new Metatypes
    {
      new Metatype(typeof(string)),
      new Metatype(typeof(int)),
      new Metatype(typeof(uint)),
      new Metatype(typeof(long)),
      new Metatype(typeof(ulong)),
      new Metatype(typeof(float)),
      new Metatype(typeof(double)),
      new Metatype(typeof(DateTime)),
      new Metatype(typeof(Guid)),
      new Metatype(typeof(Iml.Modeling.ModelElement)),
    };

  }
}

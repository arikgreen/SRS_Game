using System;
using System.Reflection;
using MVVM;
using IMLM = Iml.Modeling;
using MyLib.Controls;
using System.Windows.Data;

namespace IML.ModelEdit
{
  /// <summary>
  /// Model widoku wartości wyliczeniowej
  /// </summary>
  public partial class EnumValue : MetamodelingElement
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public EnumValue ()
    {
      ImlValue = new IMLM.EnumValue();
      PropertyChanged += EnumValue_PropertyChanged;
    }

    /// <summary>
    /// Powiązanie sygnatury z nazwą i wartością
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    void EnumValue_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs args)
    {
      if (ImlValue != null)
        CopyTo(ImlValue);
      if (args.PropertyName == "Name" || args.PropertyName == "Value")
        NotifyPropertyChanged("Signature");
    }


    /// <summary>
    /// Wartość z IML
    /// </summary>
    public IMLM.EnumValue ImlValue { get; protected set; }

    /// <summary>
    /// Ładowanie danych z informacji o polu C#
    /// </summary>
    /// <param name="info"></param>
    public void LoadFrom (FieldInfo info)
    {
      try
      {
        this.ImlValue = new IMLM.EnumValue();
        this.Name = info.Name;
        object value = info.GetValue(null);
        if (value != null)
          this.Value = (int)value;
        if (ParentType != null && ParentType.Metamodel != null)
        {
          LoadResourcesFrom(ParentType.Metamodel.GetXmlDocsDictionary());
          LoadResourcesFrom(ParentType.Metamodel.GetStringResourceDictionary());
        }
      }
      catch { }
    }

    /// <summary>
    /// Dostęp do metamodelu klasy macierzystej właściwości
    /// </summary>
    protected override IDictionaryProvider DictionaryProvider
    {
      get
      {
        if (ParentType != null)
          return ParentType.Metamodel;
        return null;
      }
    }

    /// <summary>
    /// Nazwa główna łańcucha tekstowego w zasobach
    /// </summary>
    protected override string ResourceName
    {
      get
      {
        if (ParentType != null)
          return ParentType.Name + "." + Name;
        return null;
      }
    }

    /// <summary>
    /// Sygnatura składająca się z nazwy i (opcjonalnie) wartości
    /// </summary>
    public override string Signature
    {
      get
      {
        string result = Name;
        if (Value != null)
        {
          result += " = " + Value;
        }
        return result;
      }
    }

    /// <summary>
    /// Wartość własna
    /// </summary>
    [DataProperty(LabelPath = "EnumValue", Protected = true, TrimInput=true, 
      RegEx = RegExFieldRule.Number)]
    [Binding("DataConverter", Source="IntegerValueConverter")]
    public int? Value
    {
      get { return fValue; }
      set
      {
        if (fValue != value)
        {
          fValue = value;
          if (ImlValue != null)
            ImlValue.Value = value;
          NotifyPropertyChanged("Value");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące wartość własną
    /// </summary>
    protected int? fValue;


    /// <summary>
    /// Typ, do którego należy ta wartość
    /// </summary>
    public EnumType ParentType
    {
      get
      {
        return fParentType;
      }
      set
      {
        if (fParentType != value)
        {
          fParentType = value;
          NotifyPropertyChanged("ParentType");
        }
      }
    }
    private EnumType fParentType;

    /// <summary>
    /// Zaimplementowana metoda kopiowania właściwości
    /// </summary>    
    /// <param name="other">obiekt docelowy</param>
    /// <param name="compareLocalizedProperties">czy kopiować dane lokalizowane</param>
    public override void CopyTo (object other, bool copyLocalizedProperties)
    {
      if (other is EnumValue)
        CopyTo((EnumValue)other, copyLocalizedProperties);
      else if (other is IMLM.EnumValue)
        CopyTo((IMLM.EnumValue)other);
    }

    /// <summary>
    /// Kopiowanie elementu tej samej klasy
    /// </summary>
    /// <param name="other">Inna instancja tej samej klasy</param>
    /// <param name="copyLocalizedProperties">czy kopiować dane lokalizowane</param>
    public void CopyTo (EnumValue other, bool copyLocalizedProperties)
    {
      other.Name = this.Name;
      other.Value = this.Value;
      if (!copyLocalizedProperties)
        return;
      other.DisplayName = this.DisplayName;
      other.Description = this.Description;
    }

    /// <summary>
    /// Kopiowanie elementu do IML
    /// </summary>
    /// <param name="target"></param>
    public void CopyTo (IMLM.EnumValue target)
    {
      target.Name = this.Name;
      target.Value = this.Value;
    }

    /// <summary>
    /// Zaimplementowana metoda porównania właściwości z innym obiektem
    /// </summary>
    /// <param name="other">obiekt docelowy</param>
    /// <param name="compareLocalizedProperties">czy porównywać lokalizowane dane</param>
    public override bool EqualsTo(object other, bool compareLocalizedProperties)
    {
      if (other is EnumValue)
        return EqualsTo((EnumValue)other, compareLocalizedProperties);
      return this != other;
    }

    /// <summary>
    /// Porównanie właściwości instancji tej samej klasy
    /// </summary>
    /// <param name="other">inna instancja tej samej klasy</param>
    /// <param name="compareLocalizedProperties">czy porównywać lokalizowane dane</param>
    public bool EqualsTo(EnumValue other, bool compareLocalizedProperties)
    {
      bool result =
        other.Name == this.Name &&
        other.Value == this.Value;
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
    public bool CoreEqualsTo(EnumValue other)
    {
      return
        other.Name == this.Name &&
        other.Value == this.Value;
    }

    /// <summary>
    /// Dostęp do metamodelu klasy macierzystej właściwości
    /// </summary>
    public Metamodel Metamodel
    {
      get
      {
        if (ParentType != null)
          return ParentType.Metamodel;
        return null;
      }
    }

    /// <summary>
    /// Czy definicja wartości jest chroniona przed zmianą.
    /// </summary>
    public bool IsProtected
    {
      get
      {
        if (Metamodel != null)
          return Metamodel.IsProtected;
        else
          return false;
      }
    }

    /// <summary>
    /// Czy wartość wymaga rekompilacji metamodelu
    /// </summary>
    public override bool NeedsCompilation()
    {
      return !CoreEqualsTo(this.OriginalInstance as EnumValue);
    }
  }
}


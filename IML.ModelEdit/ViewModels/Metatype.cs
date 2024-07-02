using System;
using MVVM;
using MyLib.OrdNumbers;
using IMLM = Iml.Modeling;

namespace IML.ModelEdit
{
  /// <summary>
  /// Model widoku metatypu
  /// </summary>
  public partial class Metatype : MetamodelingElement
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Metatype ()
    {
      PropertyChanged += Metatype_PropertyChanged;
    }

    /// <summary>
    /// Konstruktor inicjujący z typu C#.
    /// </summary>
    public Metatype (Type imlMetatype)
    {
      PropertyChanged += Metatype_PropertyChanged;
      LoadFrom(imlMetatype);
    }

    /// <summary>
    /// Zmiana właściwości modelu widoku powoduje zmianę właściwości metatypu z IML
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    void Metatype_PropertyChanged (object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
      if (ImlMetatype == null)
        return;
      CopyTo((object)ImlMetatype);
    }

    /// <summary>
    /// Metatyp z IML
    /// </summary>
    public IMLM.Type ImlMetatype { get; protected set; }

    /// <summary>
    /// Macierzysty metamodel
    /// </summary>
    public Metamodel Metamodel
    {
      get
      {
        return fMetamodel;
      }
      set
      {
        if (fMetamodel != value)
        {
          fMetamodel = value;
          NotifyPropertyChanged("Metamodel");
        }
      }
    }
    private Metamodel fMetamodel;

    /// <summary>
    /// Ładowanie metatypu z typu C#
    /// </summary>
    /// <param name="type"></param>
    public virtual void LoadFrom (Type type)
    {
      this.ImlMetatype = new IMLM.Type();
      this.Name = type.Name;
      this.Type = type;
      if (Metamodel != null)
      {
        LoadResourcesFrom(Metamodel.GetXmlDocsDictionary());
        LoadResourcesFrom(Metamodel.GetStringResourceDictionary());
      }
    }

    /// <summary>
    /// Nazwa główna łańcucha tekstowego w zasobach
    /// </summary>
    protected override string ResourceName
    {
      get { return Name; }
    }

    /// <summary>
    /// Typ implementacyjny
    /// </summary>
    public Type Type
    {
      get { return fType; }
      set
      {
        if (fType != value)
        {
          fType = value;
          NotifyPropertyChanged("Type");
        }
      }
    }
    /// <summary>
    /// Pole przechowujące typ implementacyjny
    /// </summary>
    protected Type fType;

    /// <summary>
    /// Macierzysty metamodel jest źródłem zasobów tekstowych
    /// </summary>
    protected override IDictionaryProvider DictionaryProvider
    {
      get { return Metamodel; }
    }

    /// <summary>
    /// Metoda kopiowania do innego obiektu
    /// </summary>    
    public override void CopyTo (object other, bool copyLocalizedProperties)
    {
      if (other is Metatype)
        CopyTo((Metatype)other, copyLocalizedProperties);
      else if (other is IMLM.Type)
        CopyTo((IMLM.Type)other);
    }

    /// <summary>
    /// Kopiowanie elementu tej samej klasy
    /// </summary>
    /// <param name="other"></param>
    /// <param name="copyLocalizedProperties"></param>
    public void CopyTo (Metatype other, bool copyLocalizedProperties)
    {
      other.Metamodel = this.Metamodel;
      base.CopyTo(other, copyLocalizedProperties);
    }

    /// <summary>
    /// Kopiowanie elementu do metaklasy IML
    /// </summary>
    /// <param name="target"></param>
    public void CopyTo (IMLM.Type target)
    {
      target.Name = this.Name;
    }

    /// <summary>
    /// Zaimplementowana metoda porównania właściwości
    /// </summary>
    /// <param name="other">inny element</param>
    /// <param name="compareLocalizedProperties">czy porównywać lokalizowane dane</param>
    public override bool EqualsTo (object other, bool compareLocalizedProperties)
    {
      if (other is Metatype)
        return EqualsTo((Metatype)other);
      return this != other;
    }

    /// <summary>
    /// Porównanie właściwości instancji tej samej klasy
    /// </summary>
    /// <param name="other">inna instancja tej samej klasy</param>
    /// <param name="compareLocalizedProperties">czy porównywać lokalizowane dane</param>
    public bool EqualsTo(Metatype other, bool compareLocalizedProperties)
    {
      return
        other.Metamodel == this.Metamodel &&
        base.EqualsTo(other, compareLocalizedProperties);
    }

    /// <summary>
    /// Kolejność na liście deklaracji
    /// </summary>
    public OrdNum Order { get; set; }

    /// <summary>
    /// Czy definicja typu jest chroniona przed zmianą.
    /// </summary>
    public bool IsProtected
    {
      get 
      {
        if (Metamodel != null)
          return Metamodel.IsProtected;
        return false;
      }
    }

    /// <summary>
    /// Czy wartość wymaga rekompilacji metamodelu
    /// </summary>
    public override bool NeedsCompilation()
    {
      return !EqualsTo(this.OriginalInstance as Metatype, false);
    }

  }
}


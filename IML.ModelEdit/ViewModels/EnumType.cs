using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using IMLM = Iml.Modeling;
using System.Collections.Specialized;
using System.Diagnostics;
using Dictionary = MVVM.Dictionary;
using System.Windows.Markup;

namespace IML.ModelEdit
{
  /// <summary>
  /// Model widoku metaklasy
  /// </summary>
  [ContentProperty("Values")]
  public partial class EnumType : Metatype
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public EnumType ()
    {
    }

    /// <summary>
    /// Metaklasa z IML
    /// </summary>
    public IMLM.EnumType ImlType
    {
      get { return base.ImlMetatype as IMLM.EnumType; }
      protected set { base.ImlMetatype = value; }
    }

    /// <summary>
    /// Ładowanie typu wyliczeniowego z typu C#
    /// </summary>
    /// <param name="type"></param>
    public override void LoadFrom (Type type)
    {
      this.ImlMetatype = new IMLM.EnumType();
      this.Name = type.Name;
      this.Type = type;
      if (Metamodel != null)
      {
        LoadResourcesFrom(Metamodel.GetXmlDocsDictionary()); 
        LoadResourcesFrom(Metamodel.GetStringResourceDictionary());
      }
      Values.LoadFrom(type);
    }

    ///// <summary>
    ///// Zapisanie zasobów tekstowych typu w słowniku
    ///// </summary>
    //public override void StoreResourcesTo (Dictionary dictionary)
    //{
    //  base.StoreResourcesTo(dictionary);
    //  Values.StoreResourcesTo(dictionary);
    //}

    /// <summary>
    /// Właściwości danej metaklasy
    /// </summary>
    public EnumValues Values
    {
      get
      {
        if (fValues == null)
          fValues = new EnumValues(this);
        return fValues;
      }
    }
    private EnumValues fValues;

    /// <summary>
    /// Przy zmianie kolekcji VM jest zmieniana kolekcja IML
    /// </summary>
    public void PropertiesCollectionChanged (object sender, NotifyCollectionChangedEventArgs args)
    {
      switch (args.Action)
      {
        case NotifyCollectionChangedAction.Add:
          foreach (EnumValue item in args.NewItems)
            Values.Add(item.ImlValue);
          break;
        case NotifyCollectionChangedAction.Remove:
          foreach (EnumValue item in args.OldItems)
            Values.Remove(item.ImlValue);
          break;
        case NotifyCollectionChangedAction.Reset:
          break;
      }
    }

    /// <summary>
    /// Zaimplementowana metoda kopiowania właściwości
    /// </summary>    
    public override void CopyTo (object other)
    {
      if (other is EnumType)
        CopyTo((EnumType)other);
      else if (other is IMLM.EnumType)
        CopyTo((IMLM.EnumType)other);
    }

    /// <summary>
    /// Kopiowanie elementu tej samej klasy
    /// </summary>
    /// <param name="other"></param>
    public void CopyTo (EnumType other)
    {
      other.Name = this.Name;
      other.DisplayName = this.DisplayName;
      other.Description = this.Description;
    }

    /// <summary>
    /// Kopiowanie elementu do metaklasy IML
    /// </summary>
    /// <param name="target"></param>
    public void CopyTo (IMLM.EnumType target)
    {
      target.Name = this.Name;
    }

    /// <summary>
    /// Zaimplementowana metoda porównania właściwości
    /// </summary>
    /// <param name="other"></param>
    public override bool EqualsTo (object other)
    {
      if (other is EnumType)
        return EqualsTo((EnumType)other);
      return this != other;
    }

    /// <summary>
    /// Porównanie właściwości instancji tej samej klasy
    /// </summary>
    /// <param name="other"></param>
    public bool EqualsTo (EnumType other)
    {
      return
        other.Name == this.Name &&
        other.DisplayName == this.DisplayName &&
        other.Description == this.Description;
    }

    /// <summary>
    /// Odświeżanie zasobów
    /// </summary>
    public override void LoadResources ()
    {
      base.LoadResources();
      if (Values != null)
        Values.RefreshResources();
    }
  }
}


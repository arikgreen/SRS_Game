using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Reflection;
using MVVM;
using MyLib.OrdNumbers;
using Dictionary = MVVM.Dictionary;
using IMLM = Iml.Modeling;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kolekcja metaklas metamodelu
  /// </summary>
  public class EnumValues : ViewModelsEditableList<EnumValue>
  {
    /// <summary>
    /// Konstruktor inicjujący z metaklasy
    /// </summary>
    /// <param name="metaclass">macierzysty metaklasa</param>
    public EnumValues (EnumType metaclass)
      : base()
    {
      ParentType = metaclass;
      CollectionChanged += ParentType.PropertiesCollectionChanged;
      CollectionChanged += EnumValues_CollectionChanged;
    }

    ///// <summary>
    ///// Przy zmianie kolekcji VM jest zmieniana kolekcja IML
    ///// </summary>
    ///// <param name="args"></param>
    //protected override void OnCollectionChanged (NotifyCollectionChangedEventArgs args)
    //{
    //  EnumValues_CollectionChanged(this, args);
    //}

    /// <summary>
    /// Przy zmianie kolekcji VM jest zmieniana kolekcja IML
    /// </summary>
    public void EnumValues_CollectionChanged (object sender, NotifyCollectionChangedEventArgs args)
    {
      if (ParentType == null)
        return;
      IMLM.EnumType imlType = ParentType.ImlType;
      if (imlType == null)
        return;
      switch (args.Action)
      {
        case NotifyCollectionChangedAction.Add:
          foreach (EnumValue item in args.NewItems)
            imlType.Values.Add(item.ImlValue);
          break;
        case NotifyCollectionChangedAction.Remove:
          foreach (EnumValue item in args.OldItems)
            imlType.Values.Remove(item.ImlValue);
          break;
        case NotifyCollectionChangedAction.Reset:
          break;
      }
    }

    /// <summary>
    /// Macierzysty typ wyliczeniowy
    /// </summary>
    public EnumType ParentType { get; private set; }

    /// <summary>
    /// Kolekcja jest ładowana przez <see cref="LoadFrom"/>
    /// </summary>
    protected override void OnLoad ()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Ładowanie kolekcji właściwości metaklasy z określonego typu
    /// </summary>
    public void LoadFrom (Type enumType)
    {
      List<FieldInfo> allProperties = GetEnumValues(enumType);

      foreach (FieldInfo info in allProperties)
      {
        EnumValue metaproperty = new EnumValue { ParentType = this.ParentType };
        metaproperty.LoadFrom(info);
        this.Add(metaproperty);
      }
      NotifyPropertyChanged("EnumValues");
    }

    /// <summary>
    /// Pobranie właściwości metaklasy z określonego typu
    /// </summary>
    /// <returns></returns>
    public static List<FieldInfo> GetEnumValues (Type metaclassType)
    {
      List<KeyValuePair<OrdNum, FieldInfo>> temp = new List<KeyValuePair<OrdNum, FieldInfo>>();
      int n = 0;
      foreach (FieldInfo info in metaclassType.GetFields(BindingFlags.Static | BindingFlags.Public ))
      {

        //IML.MetaclassPropertyAttribute attribute =
        //  (IML.MetaclassPropertyAttribute)info.GetCustomAttribute(typeof(IML.MetaclassPropertyAttribute), true);

        //if (attribute != null)
        //{
        OrdNum order = n++;// attribute.Order ?? "255";
          temp.Add(new KeyValuePair<OrdNum, FieldInfo>(order, info));
        //}
      }
      temp.Sort((item1, item2) => item1.Key.CompareTo(item2.Key));
      List<FieldInfo> result = new List<FieldInfo>(from item in temp select item.Value);
      return result;
    }

    /// <summary>
    /// Elementy są zapamiętywane przez typ macierzysty
    /// </summary>
    protected override void OnStore ()
    {
      if (ParentType != null)
        ParentType.Store();
    }

    /// <summary>
    /// Zapisanie zasobów tekstowych elementów w słowniku
    /// </summary>
    public void StoreResourcesTo (Dictionary dictionary)
    {
      foreach (EnumValue metaproperty in this)
        metaproperty.StoreResourcesTo(dictionary);
    }

    ///// <summary>
    ///// Kopiowanie do kolekcji IML
    ///// </summary>
    ///// <param name="target"></param>
    //public void CopyTo (IML.EnumValues target)
    //{
    //  foreach (VM.EnumValue metaclass in this)
    //  {
    //    IML.EnumValue imlEnumValue = new IML.EnumValue();
    //    metaclass.CopyTo(imlEnumValue);
    //    target.Add(imlEnumValue);
    //  }
    //}

    /// <summary>
    /// Odświeżenie zasobów tekstowych
    /// </summary>
    public void RefreshResources ()
    {
      foreach (EnumValue item in this)
        item.LoadResources();
      //if (CurrentItem != null && SelectedItem != null)
      //  SelectedItem.CopyTo(CurrentItem);
    }

    /// <summary>
    /// Komunikat dla potwierdzenia usunięcia elementu
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    protected override string DeleteConfirmMessage(EnumValue element)
    {
      return string.Format(MetamodelsStrings.DeleteEnumValueConfirm_1, element.Name);
    }
  }
}


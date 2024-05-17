using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using MVVM;
using MyLib.OrdNumbers;
using IMLM = Iml.Modeling;

namespace IML.ModelEdit
{
  /// <summary>
  /// Kolekcja metaklas metamodelu
  /// </summary>
  public class ClassProperties : ViewModelsEditableList<ClassProperty>
  {
    /// <summary>
    /// Konstruktor inicjujący z metaklasy
    /// </summary>
    /// <param name="metaclass">macierzysty metaklasa</param>
    public ClassProperties (Metaclass metaclass)
      : base()
    {
      Metaclass = metaclass;
    }

    /// <summary>
    /// Macierzysty metamodel metaklasy
    /// </summary>
    public Metaclass Metaclass { get; private set; }

    /// <summary>
    /// Kolekcja jest ładowana przez <see cref="LoadFrom"/>
    /// </summary>
    protected override void OnLoad ()
    {
      LoadFrom(Metaclass.Type);
    }

    /// <summary>
    /// Ładowanie kolekcji właściwości metaklasy z określonego typu
    /// </summary>
    public void LoadFrom (Type metaclassType)
    {
      List<PropertyInfo> allProperties = GetMetaproperties(metaclassType);

      foreach (PropertyInfo info in allProperties)
      {
        ClassProperty metaproperty = new ClassProperty { Metaclass = this.Metaclass, DeclaringType = info.DeclaringType.Name };
        metaproperty.LoadFrom(info);
        this.Add(metaproperty);
      }
      NotifyPropertyChanged("Metaproperties");
    }

    /// <summary>
    /// Pobranie właściwości metaklasy z określonego typu
    /// </summary>
    /// <returns></returns>
    public static List<PropertyInfo> GetMetaproperties (Type metaclassType)
    {
      List<KeyValuePair<OrdNum, PropertyInfo>> temp = new List<KeyValuePair<OrdNum, PropertyInfo>>();
      foreach (PropertyInfo info in metaclassType.GetProperties())
      {
        
        IMLM.MetaclassPropertyAttribute attribute =
          (IMLM.MetaclassPropertyAttribute)info.GetCustomAttribute(typeof(IMLM.MetaclassPropertyAttribute), true);

        if (attribute != null)
        {
          OrdNum order = attribute.Order ?? "255";
          temp.Add(new KeyValuePair<OrdNum, PropertyInfo>(order, info));
        }
      }
      temp.Sort((item1, item2) => item1.Key.CompareTo(item2.Key));
      List<PropertyInfo> result = new List<PropertyInfo>(from item in temp select item.Value);
      return result;
    }

    /// <summary>
    /// Tylko zasoby tekstowe elementów są zapamiętywane i to przez <see cref="StoreResourcesTo"/>
    /// </summary>
    protected override void OnStore ()
    {
      if (Metaclass != null)
        Metaclass.Store();
    }


    /// <summary>
    /// Komunikat dla potwierdzenia usunięcia elementu
    /// </summary>
    /// <param name="element"></param>
    /// <returns></returns>
    protected override string DeleteConfirmMessage(ClassProperty element)
    {
      return string.Format(MetamodelsStrings.DeleteClassPropertyConfirm_1, element.Name);
    }
  }
}

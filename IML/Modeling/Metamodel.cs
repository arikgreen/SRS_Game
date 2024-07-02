using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Windows.Markup;
using MyLib.OrdNumbers;

namespace Iml.Modeling
{
  /// <summary>
  /// Abstrakcyjna klasa metamodelu. Udostępnia listę metatypów
  /// </summary>
  [ContentProperty("Metatypes")]
  public class Metamodel: Object
  {
    /// <summary>
    /// Nazwa własna metamodelu
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

    /// <summary>
    /// Kolekcja definicji klas modelu
    /// </summary>
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
    public Types Metatypes
    {
      get 
      {
        if (fMetatypes == null)
          fMetatypes = new Types(this);
        return fMetatypes; 
      }
    }
    private Types fMetatypes;


    /// <summary>
    /// Pobranie klas elementów semantycznych z wywołującego modułu.
    /// </summary>
    /// <returns></returns>
    public static List<System.Type> GetMetatypes()
    {
      List<KeyValuePair<OrdNum, System.Type>> temp = new List<KeyValuePair<OrdNum, System.Type>>();
      Assembly assembly = Assembly.GetCallingAssembly();
      foreach (System.Type aType in assembly.GetTypes())
      {
        MetaclassAttribute metaclassAttribute =
          (MetaclassAttribute)aType.GetCustomAttribute(typeof(MetaclassAttribute), false);

        if (metaclassAttribute != null)
        {
          OrdNum order = metaclassAttribute.Order ?? "255";
          temp.Add(new KeyValuePair<OrdNum, System.Type>(order, aType));
        }
        else
        {
          MetatypeAttribute metatypeAttribute =
            (MetatypeAttribute)aType.GetCustomAttribute(typeof(MetatypeAttribute), false);

          if (metatypeAttribute != null)
          {
            OrdNum order = metatypeAttribute.Order ?? "255";
            temp.Add(new KeyValuePair<OrdNum, System.Type>(order, aType));
          }
        }
      }
      temp.Sort((item1, item2) => item1.Key.CompareTo(item2.Key));
      List<System.Type> result = new List<System.Type>(from item in temp select item.Value);
      return result;
    }

  }
}

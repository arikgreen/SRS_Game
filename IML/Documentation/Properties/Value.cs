using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Iml.Foundation;

namespace Iml.Documentation

{

  /// <summary>
  /// Wartość właściwości
  /// </summary>
  public partial class Value: Item
  {

    /// <summary>
    /// Identyfikator domyślny nie jest serializowany
    /// </summary>
    [DefaultValue(null)]
    public override string Id
    {
      get
      {
        return null;
      }
      set
      {
        base.Id = value;
      }
    }
    ///// <summary>
    ///// Skrót tworzony na podstawie nazwy lub pozycji w kolekcji
    ///// </summary>
    //public override int GetHash ()
    //{
    //  if (Collection != null)
    //    return Collection.IndexOf(this);
    //  return 0;
    //}


    /// <summary>
    /// Typ właściwości
    /// </summary>
    [DefaultValue(null)]
    public ValueType Type { get; set; }

    ///// <summary>
    ///// Dolne granice indeksów
    ///// </summary>
    //[DefaultValue(null)]
    //public string LowerBounds { get; set; }
    ///// <summary>
    ///// Górne granice indeksów
    ///// </summary>
    //[DefaultValue(null)]
    //public string UpperBounds { get; set; }

    /// <summary>
    /// Wersja (dla typu wersjonowanego)
    /// </summary>
    [DefaultValue(null)]
    public string Version { get; set; }

    /// <summary>
    /// Wartość właściwości (tekstowa)
    /// </summary>
    [DefaultValue(null)]
    public object Val { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca właściwości dokumentu.
  /// </summary>
  [CollectionDataContract]
  public partial class Properties : ItemList<Property>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Properties()
    { }

    /// <summary>
    /// Konstruktor właściwy dla elementu zawieranego w dokumencie
    /// </summary>
    /// <param name="aOwner"></param>
    public Properties(object aOwner): base(aOwner) { }

    /// <summary>
    /// Wyszukanie właściwości o podanej nazwie
    /// </summary>
    /// <param name="name">nazwa właściwości</param>
    /// <returns></returns>
    public Property this[string name]
    {
      get { return (from item in this where name.Equals (item.Name) select item).FirstOrDefault (); }
    }

  }
}

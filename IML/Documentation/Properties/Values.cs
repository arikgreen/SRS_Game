using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca właściwości dokumentu.
  /// </summary>
  [CollectionDataContract]
  public partial class Values : ItemList<Value>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Values ()
    { }

    /// <summary>
    /// Konstruktor właściwy dla elementu zawieranego w dokumencie
    /// </summary>
    /// <param name="aOwner"></param>
    public Values (object aOwner) : base(aOwner) { }

  }

}

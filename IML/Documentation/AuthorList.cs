using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  using Iml.Foundation;
  using System.Runtime.Serialization;
  using System.Xml.Serialization;

  /// <summary>
  /// Lista autorów
  /// </summary>
  //[CollectionDataContract(Name="Authors", ItemName="Author")]
  public partial class AuthorList: ItemList<Author>
  {

    /// <summary>
    /// Konstruktor właściwy
    /// </summary>
    /// <param name="aOwner"></param>
    public AuthorList(Object aOwner): base(aOwner) { }

  }
}

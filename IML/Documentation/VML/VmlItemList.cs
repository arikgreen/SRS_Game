using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Lista elementów VML
  /// </summary>
  public partial class VmlItemList: ContentList
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public VmlItemList () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public VmlItemList (VmlItem owner) : base(owner) { }
  }
}

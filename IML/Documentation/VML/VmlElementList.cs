using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Lista elementów rysunku VML
  /// </summary>
  public partial class VmlElementList: ItemList<VmlItem>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public VmlElementList () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public VmlElementList (VmlItem owner) : base(owner) { }
  }
}

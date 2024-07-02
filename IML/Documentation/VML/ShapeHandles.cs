using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Lista uchwytów kształtu
  /// </summary>
  public partial class ShapeHandles: ItemList<ShapeHandle>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ShapeHandles () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ShapeHandles (VmlShape owner) : base(owner) { }
  }
}

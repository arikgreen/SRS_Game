using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Lista elementów dopasowujących kształt
  /// </summary>
  public partial class ShapeParameters: ItemList<ShapeParameter>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public ShapeParameters () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public ShapeParameters (Item owner) : base(owner) { }
  }
}

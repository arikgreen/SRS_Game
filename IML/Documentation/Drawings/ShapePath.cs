using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Ścieżka kształtu
  /// </summary>
  public partial class ShapePath: List<ShapePathCommand>
  {
    /// <summary>
    /// Szerokość ścieżki
    /// </summary>
    public PointValue Width { get; set; }
    /// <summary>
    /// Wysokość ścieżki
    /// </summary>
    public PointValue Height { get; set; }
  }
}

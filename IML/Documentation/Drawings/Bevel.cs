using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Kant kształtu 3D
  /// </summary>
  public partial class Bevel
  {
    /// <summary>
    /// Typ kantu
    /// </summary>
    [DefaultValue(null)]
    public string Type { get; set; }

    /// <summary>
    /// Wysokość kantu (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue Height { get; set; }

    /// <summary>
    /// Szerokość kantu (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue Width { get; set; }
  }
}

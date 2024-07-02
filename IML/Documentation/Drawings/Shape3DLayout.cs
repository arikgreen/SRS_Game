using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Wygląd nadawany na kształt, aby zrobić z niego widok 3D
  /// </summary>
  public partial class Shape3DLayout
  {

    /// <summary>
    /// Typ materiału
    /// </summary>
    [DefaultValue(null)]
    public string Material { get; set; }

    /// <summary>
    /// Głębokość kształtu - wymiar Z (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue Depth { get; set; }

    /// <summary>
    /// Wysokość "wyciągnięcia" (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue ExtrusionHeight { get; set; }

    /// <summary>
    /// Szerokość konturu (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue ContourWidth { get; set; }

    /// <summary>
    /// Kolor "wyciągnięcia"
    /// </summary>
    [DefaultValue(null)]
    public Color ExtrusionColor { get; set; }

    /// <summary>
    /// Kolor konturu
    /// </summary>
    [DefaultValue(null)]
    public Color ContourColor { get; set; }

    /// <summary>
    /// Kant górny
    /// </summary>
    [DefaultValue(null)]
    public Bevel TopBevel { get; set; }

    /// <summary>
    /// Kant dolny
    /// </summary>
    [DefaultValue(null)]
    public Bevel BottomBevel { get; set; }
  }
}

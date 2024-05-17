using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Kafelkowanie
  /// </summary>
  public partial class Tiling
  {
    /// <summary>
    /// Wyrównanie kafelek
    /// </summary>
    [DefaultValue(null)]
    public RectangleAlignment? Alignment { get; set;}

    /// <summary>
    /// Odbijanie lustrzane kafelek
    /// </summary>
    [DefaultValue(null)]
    public TileFlipping? Flipping { get; set; }

    /// <summary>
    /// Skalowanie kafalek w poziomie
    /// </summary>
    [DefaultValue(null)]
    public Percent HorizontalScale { get; set; }

    /// <summary>
    /// Skalowanie kafalek w pionie
    /// </summary>
    [DefaultValue(null)]
    public Percent VerticalScale { get; set; }

    /// <summary>
    /// Przesunięcie kafelek w poziomie
    /// </summary>
    [DefaultValue(null)]
    public PointValue HorizontalOffset { get; set; }

    /// <summary>
    /// Przesunięcie kafelek w pionie
    /// </summary>
    [DefaultValue(null)]
    public PointValue VerticalOffset { get; set; }

  }
}

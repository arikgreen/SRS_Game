using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Cień (efekt graficzny)
  /// </summary>
  public partial class Shadow: Effect
  {
    /// <summary>
    /// Typ cienia
    /// </summary>
    [DefaultValue(null)]
    public ShadowType? Type { get; set; }

    /// <summary>
    /// Czy efekt jest obracany wraz z kształtem?
    /// </summary>
    [DefaultValue(null)]
    public bool? RotateWithShape { get; set; }

    /// <summary>
    /// Kierunek rzutowania cienia
    /// </summary>
    [DefaultValue(null)]
    public RectangleAlignment? Alignment { get; set; }

    /// <summary>
    /// Kolor efektu
    /// </summary>
    [DefaultValue(null)]
    public Color Color { get; set; }

    /// <summary>
    /// Promień rozmycia (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue BlurRadius { get; set; }

    /// <summary>
    /// Kierunek rzutowania cienia (w stopniach)
    /// </summary>
    [DefaultValue(null)]
    public Angle Direction { get; set; }

    /// <summary>
    /// Odległość rzutowania cienia (w punktach)
    /// </summary>
    [DefaultValue(null)]
    public PointValue Distance { get; set; }

    /// <summary>
    /// Kąt skosu poziomego rzutowania cienia (w stopniach)
    /// </summary>
    [DefaultValue(null)]
    public Angle HorizontalSkew { get; set; }

    /// <summary>
    /// Kąt skosu pionowego rzutowania cienia (w stopniach)
    /// </summary>
    [DefaultValue(null)]
    public Angle VerticalSkew { get; set; }

    /// <summary>
    /// Współczynnik skosu poziomego rzutowania cienia (w procentach)
    /// </summary>
    [DefaultValue(null)]
    public Percent HorizontalRatio { get; set; }

    /// <summary>
    /// Współczynnik skosu pionowego rzutowania cienia (w procentach)
    /// </summary>
    [DefaultValue(null)]
    public Percent VerticalRatio { get; set; }  
  }
}

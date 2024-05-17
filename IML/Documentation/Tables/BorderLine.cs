using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Windows.Media;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca pojedynczy segment obramowania
  /// </summary>
  public partial class BorderLine
  {
    /// <summary>
    /// Umiejscowienie linii obramowania
    /// </summary>
    public BorderLinePlacement Placement { get; set; }

    /// <summary>
    /// Rodzaj linii
    /// </summary>
    [DefaultValue(null)]
    public LineKind? Kind { get; set; }

    /// <summary>
    /// Szerokość linii
    /// </summary>
    [DefaultValue(null)]
    public PointValue LineWidth { get; set; }

    /// <summary>
    /// Odstęp linii
    /// </summary>
    [DefaultValue(null)]
    public PointValue Padding { get; set; }
    
    /// <summary>
    /// Kolor linii
    /// </summary>
    [DefaultValue(null)]
    public Color LineColor { get; set; }

    /// <summary>
    /// Styl linii
    /// </summary>
    [DefaultValue(null)]
    public string LineStyle { get; set; }

  }

}

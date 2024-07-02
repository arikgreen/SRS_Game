using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Definicja sposobu rysowania linii
  /// </summary>
  public partial class Stroke
  {
    /// <summary>
    /// Grubość linii w punktach
    /// </summary>
    [DefaultValue(null)]
    public PointValue Width { get; set; }

    /// <summary>
    /// Sposób zakończenia linii
    /// </summary>
    [DefaultValue(null)]
    public LineCapType? LineCap { get; set; }

    /// <summary>
    /// Typ linii złożonej
    /// </summary>
    [DefaultValue(null)]
    public CompoundLineType? CompoundLine { get; set; }

    /// <summary>
    /// Wyrównanie linii względem krawędzi
    /// </summary>
    [DefaultValue(null)]
    public LineAlignmentType? LineAlignment { get; set; }

    /// <summary>
    /// Sposób wypełnienia linii
    /// </summary>
    [DefaultValue(null)]
    public Fill Fill { get; set; }

    /// <summary>
    /// Typ linii (sposób przerywania
    /// </summary>
    [DefaultValue(null)]
    public string LineType { get; set; }

    /// <summary>
    /// Ograniczenie łączenia linii
    /// </summary>
    [DefaultValue(null)]
    public Percent MiterLimit { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Światło sceny
  /// </summary>
  public partial class Light
  {
    /// <summary>
    /// Typ oświetlenia
    /// </summary>
    [DefaultValue(null)]
    public string Type { get; set; }

    /// <summary>
    /// Położenie (wyrównanie oświetlenia) względem sceny
    /// </summary>
    [DefaultValue(null)]
    public RectangleAlignment? Alignment { get; set; }

    /// <summary>
    /// Obrót oświetlenia w przestrzeni 3D
    /// </summary>
    [DefaultValue(null)]
    public Rotation3D Rotation { get; set; }
  }
}

using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Ustawienia kamery
  /// </summary>
  public partial class Camera
  {
    /// <summary>
    /// Typ kamery
    /// </summary>
    [DefaultValue(null)]
    public string Type { get; set; }

    /// <summary>
    /// Kąt patrzenia kamery (w stopniach)
    /// </summary>
    [DefaultValue(null)]
    public Angle FOVAngle { get; set; }

    /// <summary>
    /// Obrót kamery w przestrzeni 3D
    /// </summary>
    [DefaultValue(null)]
    public Rotation3D Rotation { get; set; }

    /// <summary>
    /// Powiększenie kamery (w procentach)
    /// </summary>
    [DefaultValue(null)]
    public Percent Zoom { get; set; }
  }
}

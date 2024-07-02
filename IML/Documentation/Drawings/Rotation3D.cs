using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Definicja obrotu w przestrzeni 3D
  /// </summary>
  public partial class Rotation3D
  {

    /// <summary>
    /// Szerokość w stopniach
    /// </summary>
    [DefaultValue(null)]
    public Angle Latitude { get; set; }

    /// <summary>
    /// Długość w stopniach
    /// </summary>
    [DefaultValue(null)]
    public Angle Longitude { get; set; }

    /// <summary>
    /// Obrót w stopniach
    /// </summary>
    [DefaultValue(null)]
    public Angle Revolution { get; set; }

  }
}

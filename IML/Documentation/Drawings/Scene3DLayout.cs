using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Definicja układu sceny 3D
  /// </summary>
  public partial class Scene3DLayout
  {
    /// <summary>
    /// Ustawienie kamery
    /// </summary>
    [DefaultValue(null)]
    public Camera Camera { get; set; }

    /// <summary>
    /// Ustawienie oświetlenia
    /// </summary>
    [DefaultValue(null)]
    public Light Lighting { get; set; }
  }
}

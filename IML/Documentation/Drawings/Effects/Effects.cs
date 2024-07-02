using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Definicje efektów graficznych
  /// </summary>
  public partial class Effects
  {
    /// <summary>
    /// Lista efektów
    /// </summary>
    [DefaultValue(null)]
    public EffectList EffectList { get; set; }
    
    /// <summary>
    /// Ustawienia sceny 3D
    /// </summary>
    [DefaultValue(null)]
    public Scene3DLayout Scene3D { get; set; }

    /// <summary>
    /// Ustawienia kształtu 3D
    /// </summary>
    [DefaultValue(null)]
    public Shape3DLayout Shape3D { get; set; }
  }
}

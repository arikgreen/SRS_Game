using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Przekształcenia obrazu
  /// </summary>
  public abstract partial class ImageTransformation: Effect
  {
    /// <summary>
    /// Kontener zawierający to przekształcenie
    /// </summary>
    [DefaultValue(null)]
    public EffectContainer Container { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Transformacja rozmycia obrazu
  /// </summary>
  public partial class BlurTransformation: ImageTransformation
  {
    /// <summary>
    /// Promień transformacji
    /// </summary>
    [DefaultValue(null)]
    public PointValue Radius { get; set; }

    /// <summary>
    /// Czy efekt może wyjść poza obszar obrazu?
    /// </summary>
    [DefaultValue(null)]
    public bool? CanExtend { get; set; }
  }
}

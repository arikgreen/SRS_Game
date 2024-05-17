using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Wypełnienie gradientowe liniowe
  /// </summary>
  public partial class LinearGradientFill: GradientFill
  {
    /// <summary>
    /// Kąt obrotu wypełnienia liniowego (w stopniach)
    /// </summary>
    [DefaultValue(null)]
    public Angle Angle { get; set; }

    /// <summary>
    /// Czy wypełnienie jest skalowane w obszarze wypełnienia
    /// </summary>
    [DefaultValue(null)]
    public bool? Scaled { get; set; }
  }
}

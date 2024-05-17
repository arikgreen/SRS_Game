using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  /// <summary>
  /// Abstrakcyjna transormacja luminancji
  /// </summary>
  public abstract partial class LuminanceTransformation: ColorTransformation
  {
    /// <summary>
    /// Wartośc transformacji (w procentach)
    /// </summary>
    public Percent Value { get; set; }
  }
}

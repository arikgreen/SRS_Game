using Iml.Documentation.Drawings;
using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  /// <summary>
  /// Kolor w modelu AHLS ze współrzędnymi rzeczywistymi w skali 0-1
  /// </summary>
  public partial class HlsColor: Color
  {
    /// <summary>
    /// Składowa <c>Alpha</c> (w procentach)
    /// </summary>
    public Percent Alpha { get; set; }
    /// <summary>
    /// Składowa <c>Hue</c> (w stopniach)
    /// </summary>
    public Angle Hue { get; set; }
    /// <summary>
    /// Składowa luminancji (w procentach)
    /// </summary>
    public Percent Luminance { get; set; }
    /// <summary>
    /// Składowa nasycenia (w procentach)
    /// </summary>
    public Percent Saturation { get; set; }
  }
}

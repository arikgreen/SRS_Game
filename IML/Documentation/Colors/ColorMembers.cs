using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  /// <summary>
  /// Składowe koloru do przekształcenia
  /// </summary>
  public enum ColorMembers
  {
    /// <summary>
    /// Składowa A
    /// </summary>
    Alpha,
    /// <summary>
    /// Składowa R
    /// </summary>
    Red,
    /// <summary>
    /// Składowa G
    /// </summary>
    Green,
    /// <summary>
    /// Składowa B
    /// </summary>
    Blue,
    /// <summary>
    /// Składowa H (w modelu HLS)
    /// </summary>
    Hue,
    /// <summary>
    /// Składowa L (w modelu HLS)
    /// </summary>
    Luminance,
    /// <summary>
    /// Składowa S (w modelu HLS)
    /// </summary>
    Saturation
  }
}

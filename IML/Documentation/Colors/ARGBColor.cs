using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  /// <summary>
  /// Kolor wyrażony we współrzędnych rzeczywistych 0-1
  /// </summary>
  public partial class ARGBColor: Color
  {
    /// <summary>
    /// Składowa <c>Alpha</c>
    /// </summary>
    [DefaultValue(null)]
    public Percent Alpha { get; set; }
    /// <summary>
    /// Składowa <c>Red</c>
    /// </summary>
    [DefaultValue(null)]
    public Percent Red { get; set; }
    /// <summary>
    /// Składowa <c>Blue</c>
    /// </summary>
    [DefaultValue(null)]
    public Percent Blue { get; set; }
    /// <summary>
    /// Składowa <c>Green</c>
    /// </summary>
    [DefaultValue(null)]
    public Percent Green { get; set; }
  }
}

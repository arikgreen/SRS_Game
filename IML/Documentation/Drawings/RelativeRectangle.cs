using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Prostokąt ze współrzędnymi określanymi procentowo
  /// </summary>
  public partial class RelativeRectangle
  {
    /// <summary>
    /// Współrzędna lewej krawędzi
    /// </summary>
    [DefaultValue(null)]
    public Percent Left { get; set; }
    /// <summary>
    /// Współrzędna górnej krawędzi
    /// </summary>
    [DefaultValue(null)]
    public Percent Top { get; set; }
    /// <summary>
    /// Współrzędna prawej krawędzi
    /// </summary>
    [DefaultValue(null)]
    public Percent Right { get; set; }
    /// <summary>
    /// Współrzędna dolnej krawędzi
    /// </summary>
    [DefaultValue(null)]
    public Percent Bottom { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Obiekt reprezentujący prostokąt z określonymi czterema współrzędnymi
  /// </summary>
  public partial class Rectangle
  {
    /// <summary>
    /// Współrzędna lewej krawędzi
    /// </summary>
    [DefaultValue(null)]
    public PointValue Left { get; set; }
    /// <summary>
    /// Współrzędna górnej krawędzi
    /// </summary>
    [DefaultValue(null)]
    public PointValue Top { get; set; }
    /// <summary>
    /// Współrzędna prawej krawędzi
    /// </summary>
    [DefaultValue(null)]
    public PointValue Right { get; set; }
    /// <summary>
    /// Współrzędna dolnej krawędzi
    /// </summary>
    [DefaultValue(null)]
    public PointValue Bottom { get; set; }

  }
}

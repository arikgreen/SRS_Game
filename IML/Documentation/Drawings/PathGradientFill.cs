using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Wypełnienie gradientowe ze ścieżką
  /// </summary>
  public partial class PathGradientFill: GradientFill
  {
    /// <summary>
    /// Ścieżka wypełnienia
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Prostokąt wypełnienia
    /// </summary>
    public RelativeRectangle Rect { get; set; }
  }
}

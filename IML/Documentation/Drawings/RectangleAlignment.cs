using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Wyrównanie prostokąta
  /// </summary>
  public enum RectangleAlignment
  {
    /// <summary>
    /// Do lewego górnego rogu
    /// </summary>
    TopLeft = 0,
    /// <summary>
    /// Do góry
    /// </summary>
    Top = 1,
    /// <summary>
    /// Do prawego górnego rogu
    /// </summary>
    TopRight = 2,
    /// <summary>
    /// Do lewej
    /// </summary>
    Left = 3,
    /// <summary>
    /// Do środka
    /// </summary>
    Center = 4,
    /// <summary>
    /// Do prawej
    /// </summary>
    Right = 5,
    /// <summary>
    /// Do lewego dolnego rogu
    /// </summary>
    BottomLeft = 6,
    /// <summary>
    /// Do dołu
    /// </summary>
    Bottom = 7,
    /// <summary>
    /// Do prawego dolnego rogu
    /// </summary>
    BottomRight = 8,
  }
}

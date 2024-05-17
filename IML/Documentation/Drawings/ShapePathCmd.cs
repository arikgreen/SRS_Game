using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Komendy ścieżki kształtu
  /// </summary>
  public enum ShapePathCmd
  {
    /// <summary>
    /// Przesuń punkt
    /// </summary>
    MoveTo,
    /// <summary>
    /// Narysuj linię do punktu
    /// </summary>
    LineTo,
    /// <summary>
    /// Narysuj krzywą (3 stopnia) do punktu
    /// </summary>
    CubicBezierCurveTo,
    /// <summary>
    /// Zamknij krzywą
    /// </summary>
    ClosePath,
  }
}

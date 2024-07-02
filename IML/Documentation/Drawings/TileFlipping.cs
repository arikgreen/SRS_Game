using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Odbijanie kafelek
  /// </summary>
  public enum TileFlipping
  {
    /// <summary>
    /// Brak odbijania
    /// </summary>
    None = 0,
    /// <summary>
    /// Odbijanie w poziomie
    /// </summary>
    Horizontal = 1,
    /// <summary>
    /// Odbijanie w pionie
    /// </summary>
    Vertical = 2,
    /// <summary>
    /// Odbijanie w poziomie i w pionie
    /// </summary>
    HorizontalAndVertical = 3,
  }
}

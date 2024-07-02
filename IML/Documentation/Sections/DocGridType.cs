using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Typ siatki dokumentu
  /// </summary>
  public enum DocGridType
  {
    /// <summary>
    /// Domyślny
    /// </summary>
    Default = 0,
    /// <summary>
    /// Wyrównane linie
    /// </summary>
    Lines = 1,
    /// <summary>
    /// Wyrównane linie i znaki
    /// </summary>
    LinesAndChars = 2,
    /// <summary>
    /// Przyciąganie do pozycji znakowych
    /// </summary>
    SnapToChars = 3,
  }
}

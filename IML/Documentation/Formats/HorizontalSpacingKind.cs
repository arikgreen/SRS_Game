using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Sposób obliczania odstępów poziomych
  /// </summary>
  public enum HorizontalSpacingKind
  {
    /// <summary>
    /// Automatycznie
    /// </summary>
    Auto = 0,
    /// <summary>
    /// Względem szerokości znaków
    /// </summary>
    Relative = 1,
    /// <summary>
    /// W punktach
    /// </summary>
    Absolute = 2
  }
}

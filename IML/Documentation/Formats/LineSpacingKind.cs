using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Sposób obliczania odstępów międzyliniowych
  /// </summary>
  public enum LineSpacingKind
  {
    /// <summary>
    /// Automatycznie
    /// </summary>
    Auto = 0,
    /// <summary>
    /// Względem wysokości linii
    /// </summary>
    Relative = 1,
    /// <summary>
    /// Dokładnie w punktach
    /// </summary>
    Exact = 2,
    /// <summary>
    /// Co najmniej w punktach
    /// </summary>
    AtLeast = 3
  }
}

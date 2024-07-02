using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Sposób obliczania odstępów międzyakapitowych
  /// </summary>
  [Flags]
  public enum VerticalSpacingKind
  {
    /// <summary>
    /// Automatycznie
    /// </summary>
    Auto = 1,
    /// <summary>
    /// Względem wysokości linii
    /// </summary>
    Relative = 2,
    /// <summary>
    /// Co najmniej
    /// </summary>
    AtLeast = 4,
    /// <summary>
    /// Dokładnie
    /// </summary>
    Exact = 8,
  }
}
/*
 * Pojedyncze        Auto = true, [Relative = 1]
 * Półtorej          Auto = true, [Relative = 1,5]
 * Podwójne          Auto = true, [Relative = 2]
 * Co najmniej pt    AtLeast = true, Absolute = x
 * Dokładnie         Auto = true, Absolute = x
 * Wielokrotnie      Auto = true, Relative = x
*/
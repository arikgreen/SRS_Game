using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Sposób wyrównania linii względem punktów węzłowych
  /// </summary>
  public enum LineAlignmentType
  {
    /// <summary>
    /// Środek linii przebiega przez punkty węzłowe
    /// </summary>
    Center,
    /// <summary>
    /// Linia przebiega wewnątrz konturu
    /// </summary>
    Inset,
  }
}

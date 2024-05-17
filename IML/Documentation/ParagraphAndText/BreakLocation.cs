using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Pozycja, w której ma być umiejscowiony dalszy ciąg tekstu
  /// </summary>
  public enum BreakLocation
  {
    /// <summary>
    /// Przejście do następnej linii
    /// </summary>
    Next,
    /// <summary>
    /// Przejście do nastepnej lewej pozycji
    /// </summary>
    Left,
    /// <summary>
    /// Przejście do następnej prawej pozycji
    /// </summary>
    Right,
    /// <summary>
    /// Przejście do następnej pełnej linii
    /// </summary>
    Full,
  }
}

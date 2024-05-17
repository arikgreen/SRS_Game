using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Opcje sprawdzania tekstu
  /// </summary>
  public enum TextProofing
  {
    /// <summary>
    /// Domyślnie
    /// </summary>
    Auto = 0,
    /// <summary>
    /// Sprawdzanie tylko słownikowe
    /// </summary>
    LexicalOnly = 1,
    /// <summary>
    /// Sprawdzanie tylko gramatyczne
    /// </summary>
    GrammarOnly = 2,
    /// <summary>
    /// Sprawdzanie słownikowe i gramatyczne
    /// </summary>
    LexicalAndGrammar = 3,
    /// <summary>
    /// Brak sprawdzania
    /// </summary>
    NoProofing = 4,
  }
}

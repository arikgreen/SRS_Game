using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Atrybuty wyglądu tabeli wg OpenXML
  /// </summary>
  [Flags]
  public enum TableLook
  {
    /// <summary>
    /// Zastosuj formatowanie warunkowe dla pierwszego wiersza
    /// </summary>
    FirstRow = 0x0020,
    /// <summary>
    /// Zastosuj formatowanie warunkowe dla ostatniego wiersza
    /// </summary>
    LastRow = 0x0040, 
    /// <summary>
    /// Zastosuj formatowanie warunkowe dla pierwszej kolumny
    /// </summary>
    FirstCol = 0x0080,
    /// <summary>
    /// Zastosuj formatowanie warunkowe dla ostatniej kolumny
    /// </summary>
    LastCol = 0x0100,
    /// <summary>
    /// Nie stosuj formatowania warunkowego dla wierszy
    /// </summary>
    NoRowBand = 0x0200,
    /// <summary>
    /// Nie stosuj formatowania warunkowego dla kolumn
    /// </summary>
    NoColBand = 0x0400,
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Typ formatu
  /// </summary>
  public enum FormatType
  {
    /// <summary>
    /// Nieznany typ formatu
    /// </summary>
    unknown = 0,
    /// <summary>
    /// format tekstu
    /// </summary>
    Text,
    /// <summary>
    /// format akapitu
    /// </summary>
    Paragraph,
    /// <summary>
    /// format tabeli
    /// </summary>
    Table,
    /// <summary>
    /// format wiersza tabeli
    /// </summary>
    TableRow,
    /// <summary>
    /// format komórki tabeli
    /// </summary>
    TableCell,
    /// <summary>
    /// format części tabeli
    /// </summary>
    TablePart,
    /// <summary>
    /// format listy numerowanej
    /// </summary>
    List,
    /// <summary>
    /// Format sekcji
    /// </summary>
    Section,
    /// <summary>
    /// Format pudełka tekstowego
    /// </summary>
    TextBox,
    /// <summary>
    /// Format strony do druku
    /// </summary>
    Page,
    /// <summary>
    /// Format przypisu
    /// </summary>
    Docnote,
  }
}

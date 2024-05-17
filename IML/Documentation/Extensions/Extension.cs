using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation
{
  /// <summary>
  /// Element listy rozszerzeń
  /// </summary>
  [ContentProperty("InnerXML")]
  public partial class Extension
  {
    /// <summary>
    /// Identyfikuje poprawny "serwer", który może przetwarzać zawartość rozszerzenia
    /// </summary>
    [DefaultValue(null)]
    public string URI { get; set; }

    /// <summary>
    /// Wewnętrzna treść rozszerzenia (w XML'u)
    /// </summary>
    public string InnerXML { get; set; }
  }
}

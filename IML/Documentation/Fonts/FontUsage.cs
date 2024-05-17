using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca użycie czcionki z określonym skryptem
  /// </summary>
  public partial class FontUsage
  {
    /// <summary>
    /// Zbiór znaków wybierany z czcionki Unicode
    /// </summary>
    [DefaultValue(null)]
    public string Script { get; set; }

    /// <summary>
    /// Nazwa czcionki
    /// </summary>
    [DefaultValue(null)]
    public string FontName { get; set; }

    /// <summary>
    /// Nazwa motywu
    /// </summary>
    [DefaultValue(null)]
    public string ThemeName { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca użycie określonego języka dla określonego skryptu
  /// </summary>
  public partial class LanguageUsage
  {
    /// <summary>
    /// Zbiór znaków wybierany z czcionki Unicode
    /// </summary>
    [DefaultValue(null)]
    public string Script { get; set; }

    /// <summary>
    /// LCid języka
    /// </summary>
    [DefaultValue(null)]
    public string Lcid { get; set; }
  }
}

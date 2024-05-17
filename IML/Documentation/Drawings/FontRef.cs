using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Referencja do czcionki
  /// </summary>
  public partial class FontRef
  {
    /// <summary>
    /// Indeks koloru
    /// </summary>
    [DefaultValue(null)]
    public string Index { get; set; }
    /// <summary>
    /// Kolor czcionki
    /// </summary>
    [DefaultValue(null)]
    public Color Value { get; set; }
  }
}

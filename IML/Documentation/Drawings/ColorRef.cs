using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Referencja do koloru
  /// </summary>
  public partial class ColorRef
  {
    /// <summary>
    /// Indeks koloru
    /// </summary>
    [DefaultValue(null)]
    public int? Index { get; set; }
    /// <summary>
    /// Wartość koloru
    /// </summary>
    [DefaultValue(null)]
    public Color Value { get; set; }
  }
}

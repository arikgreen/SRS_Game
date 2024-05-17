using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Transformacja zmiany koloru
  /// </summary>
  public partial class ColorChangeTransformation: ImageTransformation
  {
    /// <summary>
    /// Kolor źródłowy
    /// </summary>
    [DefaultValue(null)]
    public Color ColorFrom { get; set; }
    /// <summary>
    /// Kolor docelowy
    /// </summary>
    [DefaultValue(null)]
    public Color ColorTo { get; set; }
  }
}

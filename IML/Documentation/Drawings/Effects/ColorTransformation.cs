using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Abstrakcyjna transformacja koloru
  /// </summary>
  public abstract partial class ColorTransformation: ImageTransformation
  {
    /// <summary>
    /// Kolor efektu
    /// </summary>
    [DefaultValue(null)]
    public Color Color { get; set; }
  }
}

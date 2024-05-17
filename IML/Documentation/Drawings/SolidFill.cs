using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Klasa reprezentująca wypełnienie jednolite
  /// </summary>
  public partial class SolidFill: Fill
  {
    /// <summary>
    /// Kolor wypełnienia
    /// </summary>
    [DefaultValue(null)]
    public Color Color { get; set; }
  }
}

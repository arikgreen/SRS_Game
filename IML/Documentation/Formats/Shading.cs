using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Cieniowanie elementu kolorem lub wzorem
  /// </summary>
  public partial class Shading
  {
    /// <summary>
    /// Wzorzec cieniowania
    /// </summary>
    [DefaultValue(null)]
    public string Pattern { get; set; }

    /// <summary>
    /// Kolor wypełnienia (pierwszoplanowy)
    /// </summary>
    [DefaultValue(null)]
    public Color FrontColor { get; set; }

    /// <summary>
    /// Kolor tła (drugoplanowy)
    /// </summary>
    [DefaultValue(null)]
    public Color BackColor { get; set; }
  }
}

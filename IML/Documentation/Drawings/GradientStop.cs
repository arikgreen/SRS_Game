using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Punkt kontrolny wypełnienia gradientowego
  /// </summary>
  public partial class GradientStop
  {
    /// <summary>
    /// Pozycja punktu w procentach
    /// </summary>
    [DefaultValue(null)]
    public Percent Pos { get; set; }

    /// <summary>
    /// Kolor punktu kontrolnego
    /// </summary>
    [DefaultValue(null)]
    public Color Color { get; set; }
  }
}

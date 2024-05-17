using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Kierunek tekstu
  /// </summary>
  public class TextDirection
  {
    /// <summary>
    /// Czy od prawej do lewej?
    /// </summary>
    [DefaultValue(null)]
    public bool? RightToLeft { get; set; }

    /// <summary>
    /// Czy od dołu do góry?
    /// </summary>
    [DefaultValue(null)]
    public bool? BottomToTop { get; set; }

    /// <summary>
    /// Obrót tekstu (x 90 stopni)
    /// </summary>
    [DefaultValue(false)]
    public int? Rotation { get; set; }
  }
}

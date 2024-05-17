using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Płótno - element rysunkowy
  /// </summary>
  public partial class Canvas: DrawingItem
  {
    /// <summary>
    /// Wypełnienie obwiedni
    /// </summary>
    [DefaultValue(null)]
    public Fill Background { get; set; }

    /// <summary>
    /// Formatowanie całości
    /// </summary>
    [DefaultValue(null)]
    public Outline Outline { get; set; }

    /// <summary>
    /// Lista efektów
    /// </summary>
    [DefaultValue(null)]
    public EffectList EffectList { get; set; }
  }
}

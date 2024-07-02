using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Sposób zakończenia linii
  /// </summary>
  public partial class LineEnding
  {
    /// <summary>
    /// Typ zakończenia (strzałki i inne)
    /// </summary>
    [DefaultValue(null)]
    public LineEndingType? Type { get; set; }

    /// <summary>
    /// Długość zakończenia
    /// </summary>
    [DefaultValue(null)]
    public LineEndingLength? Length { get; set; }

    /// <summary>
    /// Szerokość zakończenia
    /// </summary>
    [DefaultValue(null)]
    public LineEndingWidth? Width { get; set; }
  }
}

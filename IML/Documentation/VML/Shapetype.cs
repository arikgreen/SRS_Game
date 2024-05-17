using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Typ kształtu VML
  /// </summary>
  public partial class Shapetype: VmlShape
  {
    /// <summary>
    /// Główny element
    /// </summary>
    [DefaultValue(null)]
    public string Master { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Element sterujący kształtem przez obliczenie formuły
  /// </summary>
  public partial class ShapeParameter: Item
  {
    /// <summary>
    /// Nazwa elementu
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

    /// <summary>
    /// Formuła (w postaci tekstowej)
    /// </summary>
    [DefaultValue(null)]
    public string Formula { get; set; }
  }
}

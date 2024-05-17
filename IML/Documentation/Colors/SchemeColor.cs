using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa koloru, którego wartość jest pobierana ze schematu
  /// </summary>
  public partial class SchemeColor : Color
  {
    /// <summary>
    /// Nazwa koloru ze schematu
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

  }
}

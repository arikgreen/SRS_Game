using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa koloru, którego wartość jest pobierana ze schematu
  /// </summary>
  public partial class PresetColor : Color
  {
    /// <summary>
    /// Nazwa koloru systemowego
    /// </summary>
    public string Name { get; set; }
  }
}

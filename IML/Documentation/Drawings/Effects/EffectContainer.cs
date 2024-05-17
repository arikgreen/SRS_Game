using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Kontener na efekty wizualne
  /// </summary>
  public partial class EffectContainer: Effects
  {
    /// <summary>
    /// Nazwa kontenera
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }
    /// <summary>
    /// Typ kontenera
    /// </summary>
    [DefaultValue(null)]
    public string Type { get; set; }
  }
}

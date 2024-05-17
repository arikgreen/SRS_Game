using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Documentation.Drawings;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Klasa kształtu VML
  /// </summary>
  public partial class Shape: VmlShape
  {
    //type (Shape Type Reference)
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string TypeId { get; set; }
  }
}

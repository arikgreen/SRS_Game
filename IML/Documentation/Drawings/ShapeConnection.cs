using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Identyfikacja połączenia do kształtu
  /// </summary>
  public partial class ShapeConnection
  {
    /// <summary>
    /// Identyfikator kształtu docelowego
    /// </summary>
    [DefaultValue(null)]
    public string ShapeId { get; set; }

    /// <summary>
    /// Indeks/Id punktu docelowego w kształcie docelowym
    /// </summary>
    [DefaultValue(null)]
    public string ShapePoint { get; set; }
  }
}

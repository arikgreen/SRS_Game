using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentujaca kolumnę siatki
  /// </summary>
  public partial class TableGridCol: Item
  {
    /// <summary>
    /// Brak identyfikatora
    /// </summary>
    [DefaultValue(null)]
    public override string Id
    {
      get
      {
        return null;
      }
      set
      {
        base.Id = value;
      }
    }

    /// <summary> Szerokość kolumny w punktach</summary>
    [DefaultValue(null)]
    public PointValue Width { get; set; }

    /// <summary> Wyrównanie kolumny</summary>
    [DefaultValue(null)]
    public HorizontalAlignment? Alignment { get; set; }
  }
}

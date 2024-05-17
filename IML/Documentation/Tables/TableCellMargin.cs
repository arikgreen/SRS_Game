using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca marginesy komórki tabeli
  /// </summary>
  public partial class TableCellMargin
  {
    /// <summary>
    /// Margines od lewej
    /// </summary>
    [DefaultValue(null)]
    public TableWidth Left { get; set; }
    /// <summary>
    /// Margines od prawej
    /// </summary>
    [DefaultValue(null)]
    public TableWidth Right { get; set; }
    
    /// <summary>
    /// Margines od góry
    /// </summary>
    [DefaultValue(null)]
    public TableWidth Top { get; set; }
    /// <summary>
    /// Margines od dołu
    /// </summary>
    [DefaultValue(null)]
    public TableWidth Bottom { get; set; }

    /// <summary>
    /// Margines początku komórki
    /// </summary>
    [DefaultValue(null)]
    public TableWidth Start { get; set; }
    /// <summary>
    /// Margines końca komórki
    /// </summary>
    [DefaultValue(null)]
    public TableWidth End { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Grupa VML
  /// </summary>
  public partial class Group: VmlElement 
  {

    /// <summary>
    /// Typ diagramu do edycji elementu
    /// </summary>
    [DefaultValue(null)]
    public string EditAs { get; set; }

    /// <summary>
    /// Lista minimalnych wysokości wierszy tabeli
    /// </summary>
    [DefaultValue(null)]
    public string TableLimits { get; set; }

    /// <summary>
    /// Właściwości tabeli (w kodzie binarnym)
    /// </summary>
    [DefaultValue(null)]
    public string TableProperties { get; set; }

    /// <summary>
    /// Czy punkt zakotwiczenia grupy jest zablokowany
    /// </summary>
    [DefaultValue(null)]
    public bool? AnchorLock { get; set; }

  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Powiązanie danych
  /// </summary>
  public partial class DataBinding
  {
    /// <summary>
    /// Ścieżka XML do elementu/atrybutu danych
    /// </summary>
    [DefaultValue(null)]
    public string XPath { get; set; }

    /// <summary>
    /// Mapowanie prefiksów do XPath
    /// </summary>
    [DefaultValue(null)]
    public string PrefixMappings { get; set; }

    /// <summary>
    /// Identyfikator elementu pamiętającego dane
    /// </summary>
    [DefaultValue(null)]
    public string StoreItemID { get; set; }  
  }
}

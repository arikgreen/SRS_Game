using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Foundation
{
  /// <summary>
  /// Parametr rysunkowy
  /// </summary>
  public partial class NameValuePair: Item
  {

    /// <summary>
    /// Identyfikator jest skrótem nazwy
    /// </summary>
    [DefaultValue(null)]
    public override string Id
    {
      get
      {
        if (Name != null)
          return Name.GetHashCode().ToString("X8");
        return null;
      }
      set
      {
        base.Id = value;
      }
    }

    /// <summary>
    /// Nazwa parametru
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }
    /// <summary>
    /// Wartość parametru
    /// </summary>
    [DefaultValue(null)]
    public object Value { get; set; }
  }
}

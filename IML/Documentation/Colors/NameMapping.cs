using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Odwzorowanie jednej nazwy w drugą
  /// </summary>
  public partial class NameMapping
  {
    /// <summary>
    /// Klucz
    /// </summary>
    [DefaultValue(null)]
    public string Key { get; set; }
    /// <summary>
    /// Wartość
    /// </summary>
    [DefaultValue(null)]
    public string Value { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Object = Iml.Foundation.Object;

namespace Iml.Modeling
{
  /// <summary>
  /// Definicja wartości typu wyliczanego
  /// </summary>
  public class EnumValue : Object
  {
    /// <summary>
    /// Nazwa własna
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

    /// <summary>
    /// Wartość
    /// </summary>
    [DefaultValue(null)]
    public int? Value { get; set; }
  }
}

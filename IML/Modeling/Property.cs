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
  /// Definicja właściwości klasy modelowej
  /// </summary>
  public class Property : Object
  {
    /// <summary>
    /// Nazwa własna
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }

    /// <summary>
    /// Typ wartości
    /// </summary>
    [DefaultValue(null)]
    public string Type { get; set; }
  }
}


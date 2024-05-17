using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Modeling
{
  /// <summary>
  /// Typ wykorzystywany w modelu
  /// </summary>
  public class Type: Object
  {
    /// <summary>
    /// Nazwa własna metatypu
    /// </summary>
    [DefaultValue(null)]
    public string Name { get; set; }
  }
}

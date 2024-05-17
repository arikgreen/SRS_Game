using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Modeling
{
  /// <summary>
  /// Atrybut do oznaczania właściwości, których obiekty są zawierane w elemencie modelu
  /// </summary>
  [AttributeUsage(AttributeTargets.Property, AllowMultiple=false, Inherited=true)]
  public class ContentAttribute: Attribute
  {
    /// <summary>
    /// Semantyka zawartości (rola składnika)
    /// </summary>
    public string Semantics { get; set; }

    /// <summary>
    /// Semantyka referencji wstecznej
    /// </summary>
    public String BackwardSemantics { get; set; }
  }
}

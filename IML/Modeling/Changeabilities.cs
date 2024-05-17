using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Abstrakcyjna cecha cecha strukturalna
  /// </summary>
  public abstract partial class StructuralFeature
  {
    /// <summary>
    /// Czy wartość może być modyfikowana
    /// </summary>
    public bool IsReadOnly { get; set; }
  }
}

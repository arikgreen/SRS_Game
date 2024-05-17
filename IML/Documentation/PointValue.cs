using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Wartość rzeczywista liczona w punktach
  /// </summary>
  public partial class PointValue
  {
    /// <summary>
    /// Wartość rzeczywista w skali 0-1
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// Obliczenie skrótu na postawie wartości
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode ()
    {
      return Value.GetHashCode();
    }

  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  /// <summary>
  /// Abstrakcyjna klasa literału
  /// </summary>
  public abstract class LiteralSpecification: ValueSpecification
  {
  }

  /// <summary>
  /// Literał "null"
  /// </summary>
  public partial class LiteralNull
  {
  }

  /// <summary>
  /// Literał wartości logicznej
  /// </summary>
  public partial class LiteralBoolean
  {
    /// <summary>
    /// Wartość literału
    /// </summary>
    public Boolean Value { get; set; }
  }

  /// <summary>
  /// Literał wartości całkowitej
  /// </summary>
  public partial class LiteralInteger
  {
    /// <summary>
    /// Wartość literału
    /// </summary>
    public Integer Value { get; set; }
  }

  /// <summary>
  /// Literał wartości rzeczywistej
  /// </summary>
  public partial class LiteralReal
  {
    /// <summary>
    /// Wartość literału
    /// </summary>
    public Decimal Value { get; set; }
  }

  /// <summary>
  /// Literał wartości tekstowej
  /// </summary>
  public partial class LiteralString
  {
    /// <summary>
    /// Wartość literału
    /// </summary>
    public String Value { get; set; }
  }

  /// <summary>
  /// Literał wartości naturalnej nieskończonej
  /// </summary>
  public partial class LiteralUnlimitedNatural
  {
    /// <summary>
    /// Wartość literału
    /// </summary>
    public UnlimitedNatural Value { get; set; }
  }
}

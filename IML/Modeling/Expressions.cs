using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Abstrakcyjna klasa obejmująca <see cref="Expression"/> i <see cref="OpaqueExpression"/>
  /// </summary>
  [CanBelongTo(typeof(Expression), Semantics="expression", Subsets="owner")]
  public abstract partial class ValueSpecification : ModelElement
  {
  }

  /// <summary>
  /// Klasa reprezentująca wyrażenie (drzewo wyrażenia)
  /// </summary>
  [CanContain(typeof(ValueSpecification), Semantics = "operand", Subsets = "ownedElement", Ordered = true)]
  public partial class Expression : ValueSpecification
  {
    /// <summary>
    /// Symbol - element wyrażenia
    /// </summary>
    public string Symbol { get; set; }
  }

  /// <summary>
  /// Nieinterpretowane wyrażenie, które jest zapisane w określonym języku programowania
  /// </summary>
  public partial class OpaqueExpression : ValueSpecification
  {
    /// <summary>
    /// Treść wyrażenia (złożona z wielu łańcuchów)
    /// </summary>
    public List<string> Body { get; set; }

    /// <summary>
    /// Języki programowania
    /// </summary>
    public new List<string> Language { get; set; }
  }
}

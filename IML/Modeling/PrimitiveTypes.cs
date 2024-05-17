using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Liczba całkowita
  /// </summary>
  public partial class Integer: SemanticElement
  {
  }

  /// <summary>
  /// Wartość logiczna
  /// </summary>
  public partial class Boolean : SemanticElement
  {
  }

  /// <summary>
  /// Łańcuch znakowy
  /// </summary>
  public partial class String : SemanticElement
  {
  }

  /// <summary>
  /// Liczba naturalna bez ograniczenia
  /// </summary>
  public partial class UnlimitedNatural : SemanticElement
  {
  }

}

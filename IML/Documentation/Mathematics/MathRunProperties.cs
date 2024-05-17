using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Mathematics
{
  /// <summary>
  /// Właściwości tekstu matematycznego
  /// </summary>
  public class MathRunProperties
  {
    /*
    [ChildElementInfoAttribute(typeof(Literal))]
    [ChildElementInfoAttribute(typeof(Break))]
    [ChildElementInfoAttribute(typeof(Alignment))]
    [ChildElementInfoAttribute(typeof(Script))]
    [ChildElementInfoAttribute(typeof(Style))]
    [ChildElementInfoAttribute(typeof(NormalText))]

     */
    /// <summary>
    /// Czy zawartość ma być traktowana literalnie, a nie jako wyrażenie matematyczne
    /// </summary>
    public bool Literal { get; set; }
    /// <summary>
    /// Czy zawartość ma być traktowana jak normalny tekst
    /// </summary>
    public bool NormalText { get; set; }
    /// <summary>
    /// Style tekstu (wytłuszczony, pochylony etc.)
    /// </summary>
    public StyleValues Style { get; set; }
  }
}

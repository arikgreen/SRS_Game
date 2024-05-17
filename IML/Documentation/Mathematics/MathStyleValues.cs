using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Mathematics
{
  /// <summary>
  /// Style tekstu w wyrażeniach matematycznych
  /// </summary>
  public enum StyleValues
  {
    /// <summary>
    /// zwykły tekst
    /// </summary>
    //[EnumString("p")]
    Plain = 0,
    /// <summary>
    /// Wytłuszczony
    /// </summary>
    //[EnumString("b")]
    Bold = 1,
    /// <summary>
    /// Pochylony
    /// </summary>
    //[EnumString("i")]
    Italic = 2,
    /// <summary>
    /// Pochylony i wytłuszczony
    /// </summary>
    //[EnumString("bi")]
    BoldItalic = 3,
  }
}

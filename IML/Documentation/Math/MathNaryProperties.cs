using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Właściwości wyrażenia matematycznego z dużym operatorem
  /// </summary>
  public partial class MathNaryProperties
  {
    /// <summary>
    /// Znak symbolu.
    /// </summary>
    public string SymbolChar { get; set; }
    /// <summary>
    /// Czy operator ma być powiększony
    /// </summary>
    public bool GrowOperators { get; set; }
    /// <summary>
    /// Czy ukryć argument dolny
    /// </summary>
    public bool HideSubArgument { get; set; }
    /// <summary>
    /// Czy ukryć argument górny
    /// </summary>
    public bool HideSuperArgument { get; set; }
    /// <summary>
    /// Położenie wyrażeń granicy (argumentu dolnego i górnego)
    /// </summary>
    public LimitLocationValues LimitLocation { get; set; }
  }
}

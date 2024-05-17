using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Położenie argumentów wyrażenia z dużym operatorem (lub z granicą)
  /// </summary>
  public enum LimitLocationValues
  {
    /// <summary>
    /// Położenie pod/nad symbolem operatora
    /// </summary>
    //[EnumString("undOvr")]
    UnderOver = 0,
    /// <summary>
    /// Położenie w pozycji indeksowania dolnego/górnego
    /// </summary>
    //[EnumString("subSup")]
    SubscriptSuperscript = 1,
  }
}

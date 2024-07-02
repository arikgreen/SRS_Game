using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Typ przypisu dolnego/końcowego
  /// </summary>
  public enum DocnoteType
  {
    /// <summary>
    /// Normalny przypis
    /// </summary>
    Normal = 0,
    /// <summary>
    /// Separator przypisu
    /// </summary>
    Separator = 1,
    /// <summary>
    /// Separator uwagi
    /// </summary>
    ContinuationSeparator = 2,
    /// <summary>
    /// Uwaga kontynuacyjna
    /// </summary>
    ContinuationNotice = 3,
  }
}

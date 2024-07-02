using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// typ łączenia pionowego komórek
  /// </summary>
  public enum VerticalMergeType
  {
    /// <summary> brak łączenia pionowego</summary>
    None,
    /// <summary> rozpoczęcie łączenia pionowego</summary>
    Restart,
    /// <summary> kontynuacja łączenia pionowego</summary>
    Continue,
  }
}

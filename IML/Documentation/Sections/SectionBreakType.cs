using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Typ podziału sekcji
  /// </summary>
  public enum SectionBreakType
  {
    /// <summary>
    /// Na następnej stronie
    /// </summary>
    NextPage = 0,
    /// <summary>
    /// Na następnej kolumnie
    /// </summary>
    NextColumn = 1,
    /// <summary>
    /// Podział ciągły
    /// </summary>
    Continuous = 2,
    /// <summary>
    /// Na stronie parzystej
    /// </summary>
    EvenPage = 3,
    /// <summary>
    /// Na stronie nieparzystej
    /// </summary>
    OddPage = 4,  }
}

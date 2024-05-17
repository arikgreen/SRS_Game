using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Położenie przypisu
  /// </summary>
  public enum DocnotePosition
  {
    /// <summary>
    /// Na dole strony
    /// </summary>
    PageBottom,
    /// <summary>
    /// Pod tekstem
    /// </summary>
    BeneathText,
    /// <summary>
    /// Na końcu sekcji
    /// </summary>
    SectionEnd,
    /// <summary>
    /// Na końcu dokumentu
    /// </summary>
    DocumentEnd,
  }
}

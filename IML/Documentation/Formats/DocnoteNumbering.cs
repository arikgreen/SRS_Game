using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Iml.Documentation
{
  /// <summary>
  /// Sposób numerowania przypisów
  /// </summary>
  public enum DocnoteNumbering
  {
    /// <summary>
    /// Ciągły
    /// </summary>
    Continuous = 0,
    /// <summary>
    /// Osobny w każdej sekcji
    /// </summary>
    EachSection = 1,
    /// <summary>
    /// Osobny na każdej stronie
    /// </summary>
    EachPage = 2,
  }
}

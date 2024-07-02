using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Ukrywanie elementów
  /// </summary>
  public enum Hideable
  {
    /// <summary>
    /// Element nie jest ukrywany
    /// </summary>
    Never,
    /// <summary>
    /// Element jest ukrywany, gdy nie jest używany
    /// </summary>
    WhenUnused,
    /// <summary>
    /// Element jest zawsze ukrywany
    /// </summary>
    Always,
    /// <summary>
    /// Element nie jest ukrywany, ale jest odkrywany, gdy nie jest używany
    /// </summary>
    UnhideUsed,
  }
}

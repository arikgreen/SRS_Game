using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Typy zakończenia linii
  /// </summary>
  public enum LineEndingType
  {
    /// <summary>
    /// Brak zakończenia
    /// </summary>
    None,
    /// <summary>
    /// trójkąt
    /// </summary>
    Triangle,
    /// <summary>
    /// Strzałka wcięta
    /// </summary>
    Stealth,
    /// <summary>
    /// Romb
    /// </summary>
    Diamond,
    /// <summary>
    /// Kółko
    /// </summary>
    Oval,
    /// <summary>
    /// Strzałka prosta
    /// </summary>
    Arrow,
  }
}

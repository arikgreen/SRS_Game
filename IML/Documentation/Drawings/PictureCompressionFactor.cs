using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Stopnie kompresji obrazka
  /// </summary>
  public enum PictureCompressionFactor
  {
    /// <summary>
    /// Brak kompresji
    /// </summary>
    None = 0,
    /// <summary>
    /// Kompresja dla poczty e-mail
    /// </summary>
    Email = 1,
    /// <summary>
    /// Kompresja dla prezentacji na ekranie
    /// </summary>
    Screen = 2,
    /// <summary>
    /// Kompresja dla prezentacji w druku
    /// </summary>
    Print = 3,
    /// <summary>
    /// Kompresja dla druku wysokiej jakości
    /// </summary>
    HighQualityPrint = 4,
  }
}

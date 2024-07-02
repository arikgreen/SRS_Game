using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Traktowanie tekstu, który się nie mieści w polu tekstowym
  /// </summary>
  public enum TextOverflowHandling
  {
    /// <summary>
    /// Tekst wystaje poza pole
    /// </summary>
    Overflow,
    /// <summary>
    /// Tekst jest przycinany do pola
    /// </summary>
    Clip,
    /// <summary>
    /// Tekst jest przycinany i kończony wielokropkiem
    /// </summary>
    Ellipsis
  }
}

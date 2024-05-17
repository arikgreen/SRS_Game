using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Rodzaj linii
  /// </summary>
  public enum LineKind
  {
    /// <summary>
    /// Brak linii
    /// </summary>
    None,
    /// <summary>
    /// Linia pojedyncza cienka
    /// </summary>
    Single,
    /// <summary>
    /// Linia pojedyncza gruba
    /// </summary>
    Thick,
    /// <summary>
    /// Linia podwójna
    /// </summary>
    Double,
    /// <summary>
    /// Linia wykropkowana
    /// </summary>
    Dotted,
    /// <summary>
    /// Linia przerywana - kreskowana
    /// </summary>
    Dashed,
    /// <summary>
    /// Linia przerywana składająca się z kresek i kropek
    /// </summary>
    DotDash,
    /// <summary>
    /// Linia przerywana składająca się z dwóch kropek i kreski
    /// </summary>
    DotDotDash = 8,
  }

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Właściwości bloku matematycznego ograniczonego np. nawiasami
  /// </summary>
  public partial class MathDelimiterProperties
  {
    /// <summary>
    /// znak rozpoczynający blok (sekwencja znaków)
    /// </summary>
    public string BeginChar { get; set; }
    /// <summary>
    /// Czy operator ma być powiększony
    /// </summary>
    public bool GrowOperators { get; set; }
    /// <summary>
    /// Jak wyrównywać blok względem kształtu
    /// </summary>
    public ShapeDelimiterValues Shape { get; set; }
    /// <summary>
    /// znak oddzielający argumenty (sekwencja znaków)
    /// </summary>
    public string SeparatorChar { get; set; }
    /// <summary>
    /// znak kończący blok (sekwencja znaków)
    /// </summary>
    public string EndChar { get; set; }
  }
}

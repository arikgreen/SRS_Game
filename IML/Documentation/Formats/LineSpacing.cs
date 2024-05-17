using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca odstępy między liniami
  /// </summary>
  public partial class LineSpacing
  {
    /// <summary>
    /// Wartość liczbowa
    /// </summary>
    public double? Value { get; set; }
    /// <summary>
    /// Sposób traktowania wartości liczbowej
    /// </summary>
    public LineSpacingKind Kind { get; set; }
  }



}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca odstępy pionowe
  /// </summary>
  public partial class VerticalSpacing
  {
    /// <summary>
    /// Wartość liczbowa
    /// </summary>
    [DefaultValue(null)]
    public double? Value { get; set; }
    /// <summary>
    /// Sposób traktowania wartości liczbowej
    /// </summary>
    public VerticalSpacingKind Kind { get; set; }

  }



}

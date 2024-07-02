using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca odstępy poziome
  /// </summary>
  public partial class HorizontalSpacing
  {
    /// <summary>
    /// Wartość liczbowa
    /// </summary>
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public double Value { get; set; }
    /// <summary>
    /// Sposób traktowania wartości liczbowej
    /// </summary>
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public HorizontalSpacingKind Kind { get; set; }

    /// <summary>
    /// Odstęp automatyczny
    /// </summary>
    public static HorizontalSpacing Auto = new HorizontalSpacing { Kind = HorizontalSpacingKind.Auto };

    /// <summary>
    /// Odstęp liczony w punktach
    /// </summary>
    public static HorizontalSpacing Absolute (double value)
    {
      return new HorizontalSpacing { Kind = HorizontalSpacingKind.Absolute, Value = value };
    }

    /// <summary>
    /// Odstęp liczony w liniach
    /// </summary>
    public static HorizontalSpacing Relative (double value)
    {
      return new HorizontalSpacing { Kind = HorizontalSpacingKind.Relative, Value = value };
    }
  }
}

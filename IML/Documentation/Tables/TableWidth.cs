using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca szerokość tabeli, kolumny etc.
  /// </summary>
  public partial class TableWidth
  {
    /// <summary>
    /// Niejawna konwersja na double
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator double (TableWidth val)
    {
      return val.Value;
    }

    /// <summary>
    /// Niejawna konwersja z double
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator TableWidth (double val)
    {
      return TableWidth.Absolute(val);
    }


    /// <summary>
    /// Wartość liczbowa
    /// </summary>
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public double Value { get; set; }
    /// <summary>
    /// Sposób traktowania wartości liczbowej
    /// </summary>
    [DesignerSerializationVisibility (DesignerSerializationVisibility.Hidden)]
    public TableWidthKind Kind { get; set; }

    /// <summary>
    /// Szerokość automatyczna
    /// </summary>
    public static TableWidth Auto = new TableWidth { Kind = TableWidthKind.Auto };

    /// <summary>
    /// Szerokość liczona w punktach
    /// </summary>
    public static TableWidth Absolute (double value)
    {
      return new TableWidth { Kind = TableWidthKind.Absolute, Value = value };
    }

    /// <summary>
    /// Szerokość liczona w pct
    /// </summary>
    public static TableWidth Relative (double value)
    {
      return new TableWidth { Kind = TableWidthKind.Relative, Value = value };
    }
  }

  /// <summary>
  /// Sposób obliczania odstępów poziomych
  /// </summary>
  public enum TableWidthKind
  {
    /// <summary>
    /// Automatycznie
    /// </summary>
    Auto = 0,
    /// <summary>
    /// Względem szerokości znaków
    /// </summary>
    Relative = 1,
    /// <summary>
    /// W punktach
    /// </summary>
    Absolute = 2,
    /// <summary>
    /// Zerowa szerokość
    /// </summary>
    Nil 
  }

}

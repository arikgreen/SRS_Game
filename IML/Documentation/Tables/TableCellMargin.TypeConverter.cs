using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(TableCellMarginTypeConverter))]
  public partial class TableCellMargin
  {
    /// <summary>
    /// Konwersja na łańcuch.
    /// Łańcuch wynikowy składa się z maksymalnie 6 liczb rzeczywistych oddzielonych przecinkami.
    /// Kolejność wartości: Left, Top, Right, Bottom, Start, End.
    /// Jeśli wartość jest nieustalona (null), to nie jest wypisywana, ale przecinek jest pisany.
    /// Na przykład jeśli są ustalone tylko wartości Left=1.0 i Right=2.0,
    /// to wypisywany łańcuch ma postać: "1.0,,2.0"
    /// </summary>
    public override string ToString()
    {
        TableWidth[] values = new TableWidth[6];
        values[0] = this.Left;
        values[1] = this.Top;
        values[2] = this.Right;
        values[3] = this.Bottom;
        values[4] = this.Start;
        values[5] = this.End;
        int n = 6;
        for (; n > 0 && values[n - 1] == null; n--) ;
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < n; i++)
        {
          if (i>0)
            sb.Append(",");
          if (values[i] != null)
            sb.Append(values[i].ToString());
        }
          return sb.ToString();
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static TableCellMargin Parse (string s)
    {
      TableCellMargin result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid TableCellMargin string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out TableCellMargin result)
    {
      result = null;
      string[] ss = s.Split(',');
      TableWidth[] values = new TableWidth[6];
      for (int i = 0; i < ss.Length && i < 6; i++)
      {
        s = ss[i];
        TableWidth x;
        if (TableWidth.TryParse(s, out x))
        {
          values[i] = x;
        }
      }
      result = new TableCellMargin
      {
        Left = values[0],
        Top = values[1],
        Right = values[2],
        Bottom = values[3],
        Start = values[4],
        End = values[5]
      };
      return result != null;
    }

  }

  /// <summary>
  /// Konwerter marginesów komórki. 
  /// </summary>
  public partial class TableCellMarginTypeConverter : TypeConverter
  {
    /// <summary>
    /// Konwersja z postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
    {
      if (sourceType == typeof(string))
        return true;
      else
        return base.CanConvertFrom(context, sourceType);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
    {
      if (destinationType == typeof(string))
        return true;
      else
        return base.CanConvertTo(context, destinationType);
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        string s = (string)value;
        TableCellMargin val;
        if (TableCellMargin.TryParse(s, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is TableCellMargin)
      {
        return (value as TableCellMargin).ToString();
      }
      else
        return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}

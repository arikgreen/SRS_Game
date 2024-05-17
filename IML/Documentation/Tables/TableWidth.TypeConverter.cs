using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(TableWidthTypeConverter))]
  public partial class TableWidth
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      if (this.Kind == TableWidthKind.Auto)
        return "auto";
      else if (this.Kind == TableWidthKind.Relative)
        return (this.Value/12.0).ToString(CultureInfo.InvariantCulture) + "pct";
      else
        return this.Value.ToString(CultureInfo.InvariantCulture) + "pt";
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static TableWidth Parse(string s)
    {
      TableWidth result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid TableWidth string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out TableWidth result)
    {
      result = null;
      if (s == "auto")
        result = TableWidth.Auto;
      else if (s.EndsWith("pct"))
      {
        s = s.Substring(0, s.Length - 3).Trim();
        double x;
        if (double.TryParse(s, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out x))
          result = TableWidth.Relative(x*12);
      }
      else if (s.EndsWith("pt"))
      {
          s = s.Substring(0, s.Length - 2).Trim();
          double x;
          if (double.TryParse(s, NumberStyles.AllowDecimalPoint | NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out x))
            result = TableWidth.Absolute(x);
      }
      return result != null;
    }
  }

  /// <summary>
  /// Konwerter odległości poziomej
  /// </summary>
  public partial class TableWidthTypeConverter : TypeConverter
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
        string s = (value as string).ToLowerInvariant().Trim();
        return TableWidth.Parse(s);
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is TableWidth)
      {
        TableWidth val = (TableWidth)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{

  [TypeConverter(typeof(BorderLineTypeConverter))]
  public partial class BorderLine
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static BorderLine Parse (string str)
    {
      BorderLine result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse BorderLine from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out BorderLine value)
    {
      return FormatHelper.TryParse<BorderLine>(str, out value);
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return FormatHelper.ToString(this);
    }

    /// <summary>
    /// Konwersja na łańcuch bez wypisywania pozycji
    /// </summary>
    /// <returns></returns>
    public string ToStringNoPlacement()
    {
      StringBuilder sb = new StringBuilder();
      string result = FormatHelper.ToString(this);
      string[] ss = FormatHelper.TrySplitList(result);
      int n = 0;
      foreach (string s in ss)
      {
        if (s.StartsWith("Placement"))
          continue;
        if (n++ != 0)
          sb.Append(", ");
        sb.Append(s);
      }
      result = sb.ToString();
      return result;
    }
  }

  /// <summary>
  /// Konwerter tekstowy linii obramowania
  /// </summary>
  public partial class BorderLineTypeConverter : TypeConverter
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
        BorderLine result = BorderLine.Parse(value as string);
        return result;
      }
      else
        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is BorderLine)
      {
        BorderLine val = (BorderLine)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}



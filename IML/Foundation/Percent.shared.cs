using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Foundation
{
  [TypeConverter(typeof(PercentTypeConverter))]
  public partial class Percent
  {
    /// <summary>
    /// Niejawna transformacja na double
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator double (Percent val)
    {
      return val.Value;
    }

    /// <summary>
    /// Niejawna transformacja z double
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator Percent (double val)
    {
      return new Percent { Value = val };
    }

    /// <summary>
    /// Konwersja na postać łańcucha
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return (Value * 100).ToString(CultureInfo.InvariantCulture) + "%";
    }

    /// <summary>
    /// Konwersja na postać łańcucha
    /// </summary>
    /// <returns></returns>
    public string ToString (IFormatProvider formatProvider)
    {
      return (Value * 100).ToString(formatProvider) + "%";
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static Percent Parse (string s)
    {
      Percent result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid Percent string format");
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s">łańcuch źródłowy</param>
    /// <param name="formatProvider">dostawca formatu</param>
    /// <returns>wartość wynikowa</returns>
    public static Percent Parse (string s, IFormatProvider formatProvider)
    {
      Percent result;
      if (TryParse(s, formatProvider, out result))
        return result;
      throw new FormatException("Invalid Percent string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s">łańcuch źródłowy</param>
    /// <param name="result"></param>
    /// <returns>wartość wynikowa</returns>
    public static bool TryParse (string s, out Percent result)
    {
      return TryParse(s, CultureInfo.InvariantCulture, out result);
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s">łańcuch źródłowy</param>
    /// <param name="formatProvider">dostawca formatu</param>
    /// <param name="result">wynikowa wartość</param>
    /// <returns>czy dodanie się udało</returns>
    public static bool TryParse (string s, IFormatProvider formatProvider, out Percent result)
    {
      result = null;
      if (s == null)
        return false;
      if (s.Last() != '%')
        return false;
      s = s.Substring(0, s.Length - 1);
      double val;
      if (!double.TryParse(s, NumberStyles.Float, formatProvider, out val))
        return false;
      result = new Percent { Value = val / 100 };
      return true;
    }
  }


  /// <summary>
  /// Konwerter wartości z/na łańcuch znaków
  /// </summary>
  public partial class PercentTypeConverter : TypeConverter
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
        Percent color;
        if (Percent.TryParse(s, out color))
          return color;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string))
      {
        return value.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}

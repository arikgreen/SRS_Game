using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(LanguageUsageTypeConverter))]
  public partial class LanguageUsage
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return String.Format("{0}={1}", this.Script, this.Lcid);
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static LanguageUsage Parse (string s)
    {
      LanguageUsage result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid LanguageUsage string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out LanguageUsage result)
    {
      result = null;
      string[] ss = (s).Split('=');
      if (ss.Length != 2)
        return false;
      result = new LanguageUsage { Script = ss[0], Lcid = ss[1] };
      return true;
    }
  }

  /// <summary>
  /// Konwerter obiektu użycia czcionki z/na łańcuch znaków
  /// </summary>
  public class LanguageUsageTypeConverter : TypeConverter
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
        LanguageUsage result;
        if (LanguageUsage.TryParse((string)value, out result))
          return result;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej.
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is LanguageUsage)
      {
        LanguageUsage val = (LanguageUsage)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}



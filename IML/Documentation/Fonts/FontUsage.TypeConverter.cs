using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(FontUsageTypeConverter))]
  public partial class FontUsage
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      if (ThemeName !=null)
        return String.Format("{0}:{1}={2}", this.Script, this.ThemeName, this.FontName);
      else
        return String.Format("{0}={1}", this.Script, this.FontName);
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static FontUsage Parse (string s)
    {
      FontUsage result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid FontUsage string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out FontUsage result)
    {
      result = null;
      string[] ss = (s).Split('=');
      if (ss.Length != 2)
        return false;
      string[] ss1 = ss[0].Split(':');
      if (ss1.Length==2)
        result = new FontUsage { Script = ss1[0], ThemeName = ss1[1], FontName = ss[1] };
      else
        result = new FontUsage { Script = ss[0], FontName = ss[1] };
      return true;
    }
  }

  /// <summary>
  /// Konwerter obiektu użycia czcionki z/na łańcuch znaków
  /// </summary>
  public partial class FontUsageTypeConverter : TypeConverter
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
        FontUsage result;
        if (FontUsage.TryParse((string)value, out result))
          return result;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej.
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is FontUsage)
      {
        FontUsage val = (FontUsage)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}


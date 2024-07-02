using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(TypefaceTypeConverter))]
  public partial class Typeface
  {
    /// <summary>
    /// Niejawna konwersja na łańcuch
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator string (Typeface val)
    {
      return val.Name;
    }

    /// <summary>
    /// Niejawna konwersja z łańcucha
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator Typeface (string val)
    {
      return new Typeface { Name = val };
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      if (this.Name != null)
        sb.Append(this.Name);
      if (this.ShouldSerializeFontSubstitutes())
        foreach (FontUsage font in this.Substitutes)
        {
          sb.Append(";");
          sb.Append(font.ToString());
        }
      return sb.ToString();
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static Typeface Parse (string s)
    {
      Typeface result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid Typeface string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out Typeface result)
    {
      result = new Typeface();
      if (s == null)
        return false;
      string[] ss = (s).Split(';');
      if (ss.Length > 0)
      {
        result.Name = ss[0];
        if (ss.Length > 1)
          for (int i=1; i<ss.Length; i++)
          {
            FontUsage font;
            if (!FontUsage.TryParse(ss[i], out font))
              return false;
            result.Substitutes.Add(font);
          }
      }
      return true;
    }

  }

  /// <summary>
  /// Konwerter obiektu <see cref="Typeface"/> z/na łańcuch znaków
  /// </summary>
  public class TypefaceTypeConverter : TypeConverter
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
        Typeface result;
        if (Typeface.TryParse((string)value, out result))
          return result;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej. Wynik: "name;fontUsage1;fontUsage2;...".
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is Typeface)
      {
        Typeface val = (Typeface)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}

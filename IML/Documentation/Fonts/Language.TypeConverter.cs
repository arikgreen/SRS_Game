using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(LanguageTypeConverter))]
  public partial class Language
  {
    /// <summary>
    /// Niejawna konwersja na łańcuch
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator string (Language val)
    {
      return val.Name;
    }

    /// <summary>
    /// Niejawna konwersja z łańcucha
    /// </summary>
    /// <param name="val"></param>
    /// <returns></returns>
    public static implicit operator Language (string val)
    {
      return new Language { Name = val };
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

      if (this.ShouldSerializeLanguageSubstitutes())
        foreach (LanguageUsage font in this.Substitutes)
        {
          if (sb.Length>0)
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
    public static Language Parse (string s)
    {
      Language result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid Language string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out Language result)
    {
      result = new Language();
      if (s == null)
        return false;
      string[] ss = (s).Split(';');
      if (ss.Length > 0)
      {
        int n = 0;
        if (!ss[0].Contains('='))
        {
          result.Name = ss[0];
          n++;
        }
        if (ss.Length > n)
          for (int i = n; i < ss.Length; i++)
          {
            LanguageUsage lang;
            if (!LanguageUsage.TryParse(ss[i], out lang))
              return false;
            result.Substitutes.Add(lang);
          }
      }
      return true;
    }

  }

  /// <summary>
  /// Konwerter obiektu <see cref="Language"/> z/na łańcuch znaków
  /// </summary>
  public class LanguageTypeConverter : TypeConverter
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
        Language result;
        if (Language.TryParse((string)value, out result))
          return result;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej. Wynik: "name;fontUsage1;fontUsage2;...".
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is Language)
      {
        Language val = (Language)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(LanguageSubstitutesTypeConverter))]
  public partial class LanguageSubstitutes
  {
  }

  /// <summary>
  /// Konwerter obiektu użycia języka z/na łańcuch znaków
  /// </summary>
  public class LanguageSubstitutesTypeConverter : TypeConverter
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
        string[] ss = ((string)value).Split(';');
        LanguageUsageTypeConverter itemConverter = new LanguageUsageTypeConverter();
        LanguageSubstitutes result = new LanguageSubstitutes();
        foreach (string s in ss)
        {
          result.Add((LanguageUsage)itemConverter.ConvertFromString(s));
        }
        return result;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej. Poszczególne elementy oddzielone średnikami
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is LanguageSubstitutes)
      {
        LanguageSubstitutes val = (LanguageSubstitutes)value;
        StringBuilder sb = new StringBuilder();
        LanguageUsageTypeConverter itemConverter = new LanguageUsageTypeConverter();
        int i = 0;
        foreach (LanguageUsage item in val)
        {
          if (i != 0)
            sb.Append(";");
          i++;
          sb.Append(itemConverter.ConvertToString(item));
        }
        return sb.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}

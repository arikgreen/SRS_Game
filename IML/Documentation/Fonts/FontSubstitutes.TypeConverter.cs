using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(FontSubstitutesTypeConverter))]
  public partial class FontSubstitutes
  {
  }

  /// <summary>
  /// Konwerter obiektu użycia czcionki z/na łańcuch znaków
  /// </summary>
  public partial class FontSubstitutesTypeConverter : TypeConverter
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
        FontUsageTypeConverter itemConverter = new FontUsageTypeConverter();
        FontSubstitutes result = new FontSubstitutes();
        foreach (string s in ss)
        {
          result.Add((FontUsage)itemConverter.ConvertFromString(s));
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
      if (destinationType == typeof(string) && value is FontSubstitutes)
      {
        FontSubstitutes val = (FontSubstitutes)value;
        StringBuilder sb = new StringBuilder();
        FontUsageTypeConverter itemConverter = new FontUsageTypeConverter();
        int i=0;
        foreach (FontUsage item in val)
        {
          if (i!=0)
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

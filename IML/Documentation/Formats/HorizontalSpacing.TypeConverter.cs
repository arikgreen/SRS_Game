using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa reprezentująca odstępy poziome
  /// </summary>
  [TypeConverter(typeof(HorizontalSpacingTypeConverter))]
  public partial class HorizontalSpacing
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static HorizontalSpacing Parse (string str)
    {
      HorizontalSpacing result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse HorizontalSpacing from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out HorizontalSpacing value)
    {
      if (s == "auto")
      {
        value = new HorizontalSpacing { Kind = HorizontalSpacingKind.Auto };
        return true;
      }
      if (s == "0")
      {
        value = new HorizontalSpacing { Value = 0, Kind = HorizontalSpacingKind.Absolute };
        return true;
      }
      double x;
      if (s.EndsWith("ch"))
      {
        s = s.Substring(0, s.Length - 2).Trim();
        if (double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out x))
        {
          value = new HorizontalSpacing { Value = x, Kind = HorizontalSpacingKind.Relative };
          return true;
        }
      }
      else if (s.EndsWith("pt"))
      {
        s = s.Substring(0, s.Length - 2).Trim();
        if (double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out x))
        {
          value = new HorizontalSpacing { Value = x, Kind = HorizontalSpacingKind.Absolute };
          return true;
        }
      }
      //else
      //{
      //  if (double.TryParse(s, out x))
      //    return new HorizontalSpacing { Value = x / 20.0, Kind = HorizontalSpacingKind.Absolute };
      //}
      //return new HorizontalSpacing { Kind = HorizontalSpacingKind.Absolute };
      value = null;
      return false;
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      if (this.Kind == HorizontalSpacingKind.Auto)
        return "auto";
      if (this.Value == 0.0)
        return "0";
      if (this.Kind == HorizontalSpacingKind.Relative)
        return this.Value.ToString(CultureInfo.InvariantCulture) + "ch";
      else
        return this.Value.ToString(CultureInfo.InvariantCulture) + "pt";
    }

  }

  /// <summary>
  /// Konwerter odległości poziomej
  /// </summary>
  public partial class HorizontalSpacingTypeConverter : TypeConverter
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
        HorizontalSpacing result;
        if (HorizontalSpacing.TryParse(s, out result))
          return result;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is HorizontalSpacing)
      {
        HorizontalSpacing val = (HorizontalSpacing)value;
        return val.ToString();
      }
      else
        return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}


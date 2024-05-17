using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(LineSpacingTypeConverter))]
  public partial class LineSpacing
  {
  }
  /// <summary>
  /// Konwerter odległości między liniami
  /// </summary>
  public partial class LineSpacingTypeConverter : TypeConverter
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
        double x;
        if (s == "auto")
          return LineSpacing.Auto;
        if (s.EndsWith("ln"))
        {
          s = s.Substring(0, s.Length - 2).Trim();
          if (double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out x))
            return new LineSpacing { Value = x, Kind = LineSpacingKind.Relative };
        }
        else if (s.StartsWith("min"))
        {
          s = s.Substring(3).Trim();
          if (s.EndsWith("pt"))
            s = s.Substring(0, s.Length - 2).Trim();
          if (double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out x))
            return new LineSpacing { Value = x, Kind = LineSpacingKind.AtLeast };
        }
        else
        {
          if (s.EndsWith("pt"))
            s = s.Substring(0, s.Length - 2).Trim();
          if (double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out x))
            return new LineSpacing { Value = x, Kind = LineSpacingKind.Exact };
        }
        return new LineSpacing { Kind = LineSpacingKind.Exact };
      }
      else
        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is LineSpacing)
      {
        LineSpacing val = (LineSpacing)value;
        if (val.Kind == LineSpacingKind.Auto)
          return "auto";
        if (val.Value != null)
        {
          if (val.Kind == LineSpacingKind.Relative)
            return ((double)val.Value).ToString(CultureInfo.InvariantCulture) + "ln";
          else
            if (val.Kind == LineSpacingKind.AtLeast)
              return "min " + ((double)val.Value).ToString(CultureInfo.InvariantCulture) + "pt";
            else
              return ((double)val.Value).ToString(CultureInfo.InvariantCulture) + "pt";
        }
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}

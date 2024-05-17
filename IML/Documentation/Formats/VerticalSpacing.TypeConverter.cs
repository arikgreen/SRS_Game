using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Globalization;
using System.Diagnostics;

namespace Iml.Documentation
{
  [TypeConverter(typeof(VerticalSpacingTypeConverter))]
  public partial class VerticalSpacing
  {
  }

  /// <summary>
  /// Konwerter odległości pionowej
  /// </summary>
  public partial class VerticalSpacingTypeConverter : TypeConverter
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
        if (s == "0")
          return new VerticalSpacing { Value = 0 };
        double x;
        VerticalSpacingKind kind = 0;
        if (s.StartsWith("auto"))
        {
          kind |= VerticalSpacingKind.Auto;
          s = s.Substring(4).Trim();
        }
        if (s.StartsWith("min"))
        {
          kind |= VerticalSpacingKind.AtLeast;
          s = s.Substring(3).Trim();
        }
        if (s.StartsWith("exact"))
        {
          kind |= VerticalSpacingKind.Exact;
          s = s.Substring(5).Trim();
        }
        if (s.EndsWith("ln"))
        {
          kind |= VerticalSpacingKind.Relative;
          s = s.Substring(0, s.Length - 2).Trim();
          if (double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out x))
            return new VerticalSpacing { Value = x, Kind = kind };
        }
        if (s.EndsWith("pt"))
        {
          s = s.Substring(0, s.Length - 2).Trim();
          if (double.TryParse(s, NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out x))
            return new VerticalSpacing { Value = x, Kind = kind };
        }
        return new VerticalSpacing { Kind = kind };
      }
      else
        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is VerticalSpacing)
      {
        StringBuilder sb = new StringBuilder();
        VerticalSpacing val = (VerticalSpacing)value;
        if (val.Kind.HasFlag(VerticalSpacingKind.Auto))
          sb.Append(" auto");
        if (val.Kind.HasFlag(VerticalSpacingKind.AtLeast))
          sb.Append(" min");
        if (val.Kind == VerticalSpacingKind.Exact)
          sb.Append(" exact");
        if (val.Value != null)
        {
          sb.Append(" ");
          if (val.Kind.HasFlag(VerticalSpacingKind.Relative))
            sb.Append(((double)val.Value).ToString(CultureInfo.InvariantCulture) + "ln");
          else
            sb.Append(((double)val.Value).ToString(CultureInfo.InvariantCulture) + "pt");
        }
        return sb.ToString().Trim();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}

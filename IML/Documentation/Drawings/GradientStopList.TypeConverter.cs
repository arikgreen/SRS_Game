using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{

  [TypeConverter(typeof(GradientStopListTypeConverter))]
  public partial class GradientStopList
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static GradientStopList Parse (string str)
    {
      GradientStopList result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse GradientStopList from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out GradientStopList value)
    {
      value = new GradientStopList();
      string[] ss = FormatHelper.SplitList(str);
      foreach (string s in ss)
      {
        GradientStop val;
        if (GradientStop.TryParse(s.TryTrimListSeparators(), out val))

          value.Add(val);
      }
      return true;
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      int n = 0;
      foreach (GradientStop item in this)
      {
        if (n++ != 0)
          sb.AppendFormat(", ");
        sb.Append("(");
        sb.Append((item as GradientStop).ToString());
        sb.Append(")");
      }
      return sb.ToString();
    }


  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class GradientStopListTypeConverter : TypeConverter
  {
    /// <summary>
    /// Konwersja z postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertFrom (ITypeDescriptorContext context, Type sourceType)
    {
      if (!(sourceType == typeof(string)))
      {
        return base.CanConvertTo(context, sourceType);
      }
      if ((context == null) || (context.Instance == null))
      {
        return true;
      }
      if (context.PropertyDescriptor != null
        && context.PropertyDescriptor.PropertyType == typeof(GradientStopList))
      {
        return true;
      }
      return false;//throw new ArgumentException("GradientStopList instance expected");
    }

    /// <summary>
    /// Konwersja do postaci tekstowej dozwolona
    /// </summary>
    public override bool CanConvertTo (ITypeDescriptorContext context, Type destinationType)
    {
      if (!(destinationType == typeof(string)))
      {
        return base.CanConvertTo(context, destinationType);
      }
      if ((context == null) || (context.Instance == null))
      {
        return true;
      }
      if (context.PropertyDescriptor != null
        && context.PropertyDescriptor.PropertyType == typeof(GradientStopList))
      {
        return true;
      }
      return false;//throw new ArgumentException("GradientStopList instance expected");
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        GradientStopList val;
        if (GradientStopList.TryParse(value as String, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if ((destinationType != null) && (value is GradientStopList))
      {
        GradientStopList val = (GradientStopList)value;
        if (destinationType == typeof(string))
        {
          return val.ToString();
        }
      }
      return base.ConvertTo(context, culture, value, destinationType);

    }
  }
}



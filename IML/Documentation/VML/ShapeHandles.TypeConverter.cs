using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{

  [TypeConverter(typeof(ShapeHandlesTypeConverter))]
  public partial class ShapeHandles
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static ShapeHandles Parse (string str)
    {
      ShapeHandles result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse ShapeHandles from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out ShapeHandles value)
    {
      value = new ShapeHandles();
      string[] ss = FormatHelper.SplitList(str);
      foreach (string s1 in ss)
      {
        string s = s1.Trim();
        if (s.StartsWith("(") && s.EndsWith(")"))
          s = s.Substring(1,s.Length-2);
        ShapeHandle val;
        if (ShapeHandle.TryParse(s, out val))
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
      foreach (ShapeHandle item in this)
      {
        if (n++ != 0)
          sb.Append(", ");
        sb.Append("(");
        sb.Append((item as ShapeHandle).ToString());
        sb.Append(")");
      }
      return sb.ToString();
    }


  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class ShapeHandlesTypeConverter : TypeConverter
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
        && context.PropertyDescriptor.PropertyType == typeof(ShapeHandles))
      {
        return true;
      }
      return false;//throw new ArgumentException("ShapeHandles instance expected");
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
        && context.PropertyDescriptor.PropertyType == typeof(ShapeHandles))
      {
        return true;
      }
      return false;//throw new ArgumentException("ShapeHandles instance expected");
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        ShapeHandles val;
        if (ShapeHandles.TryParse(value as String, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if ((destinationType != null) && (value is ShapeHandles))
      {
        ShapeHandles val = (ShapeHandles)value;
        if (destinationType == typeof(string))
        {
          return val.ToString();
        }
      }
      return base.ConvertTo(context, culture, value, destinationType);

    }
  }
}



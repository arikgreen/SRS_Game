using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{

  [TypeConverter(typeof(ShapeParametersTypeConverter))]
  public partial class ShapeParameters
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static ShapeParameters Parse (string str)
    {
      ShapeParameters result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse ShapeParameters from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out ShapeParameters value)
    {
      return FormatHelper.TryParse<ShapeParameters>(str, out value);
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return FormatHelper.ToString(this);
    }

    /// <summary>
    /// Czy może być serializowany do łańcucha
    /// </summary>
    /// <returns></returns>
    public bool CanSerializeToString ()
    {
      return Count == 1;
    }
  }

  /// <summary>
  /// Konwerter tekstowy formatu tekstowego
  /// </summary>
  public partial class ShapeParametersTypeConverter : TypeConverter
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
      if (context.PropertyDescriptor.PropertyType == typeof(ShapeParameter))
      {
        return true;
      }
      return false;//throw new ArgumentException("ShapeParameters instance expected");
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
      if (context.Instance!=null && context.Instance is DrawingShape)
      {
        return true;
      }
      return false;//throw new ArgumentException("ShapeParameters instance expected");
    }

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        ShapeParameters val;
        if (ShapeParameters.TryParse(value as String, out val))
          return val;
      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if ((destinationType != null) && (value is ShapeParameters))
      {
        ShapeParameters val = (ShapeParameters)value;
        if (destinationType == typeof(string))
        {
          return val.ToString();
        }
      }
      return base.ConvertTo(context, culture, value, destinationType);

    }
  }
}


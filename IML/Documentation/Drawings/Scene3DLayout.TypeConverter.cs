using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{

  [TypeConverter(typeof(Scene3DLayoutTypeConverter))]
  public partial class Scene3DLayout
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static Scene3DLayout Parse (string str)
    {
      Scene3DLayout result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse Scene3DLayout from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out Scene3DLayout value)
    {
      return FormatHelper.TryParse<Scene3DLayout>(str, out value);
    }

    /// <summary>
    /// Uproszczona forma tekstowa listy
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return FormatHelper.ToString(this);
    }
  }

  /// <summary>
  /// Konwerter tekstowy łącza danych
  /// </summary>
  public partial class Scene3DLayoutTypeConverter : TypeConverter
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
        Scene3DLayout result = Scene3DLayout.Parse(value as string);
        return result;
      }
      else
        return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string) && value is Scene3DLayout)
      {
        Scene3DLayout val = (Scene3DLayout)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}
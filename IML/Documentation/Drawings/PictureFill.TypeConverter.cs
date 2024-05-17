using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{

  [TypeConverter(typeof(PictureFillTypeConverter))]
  public partial class PictureFill
  {

    /// <summary>
    /// Czy może być serializowane do łańcucha
    /// </summary>
    /// <returns></returns>
    public override bool CanSerializeToString ()
    {
      return true;
    }
    
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <returns></returns>
    public static PictureFill Parse (string str)
    {
      PictureFill result;
      if (TryParse(str, out result))
        return result;
      throw new FormatException(String.Format("Cannot parse PictureFill from string \"{0}\"", str));
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="str"></param>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool TryParse (string str, out PictureFill value)
    {
      return FormatHelper.TryParse<PictureFill>(str, out value);
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return FormatHelper.ToString(this);
    }
  }

  /// <summary>
  /// Konwerter tekstowy referencji koloru
  /// </summary>
  public partial class PictureFillTypeConverter : TypeConverter
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
        PictureFill result = PictureFill.Parse(value as string);
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
      if (destinationType == typeof(string) && value is PictureFill)
      {
        PictureFill val = (PictureFill)value;
        return val.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }
}




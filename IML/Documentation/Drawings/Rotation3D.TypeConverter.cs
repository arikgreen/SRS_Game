using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  [TypeConverter(typeof(Rotation3DTypeConverter))]
  public partial class Rotation3D
  {
  }

  /// <summary>
  /// Konwerter koloru z/na łańcuch znaków
  /// </summary>
  public partial class Rotation3DTypeConverter : TypeConverter
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
        string s = (value as string).Trim();

        Rotation3D color;
        if (Rotation3D.TryParse(s, out color))
          return color;

      }
      return base.ConvertFrom(context, culture, value);
    }

    /// <summary>
    /// Konwersja do postaci tekstowej. Jeśli kolor jest jednym ze znanych, to podaje jego nazwę.
    /// Jeśli nie, to podaje wartość koloru w postaci szesnastkowej. I tu: jeśli wartość kanału Alpha jest równa 0xFF,
    /// to podaje tylko wartość RGB (6 cyfr szesnastkowych), w przeciwnym wypadku pełne 8 cyfr szesnastkowych.
    /// </summary>
    public override object ConvertTo (ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
    {
      if (destinationType == typeof(string))
      {
        return value.ToString();
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}

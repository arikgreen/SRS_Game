using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(PresetColorTypeConverter))]
  public partial class PresetColor
  {
  }

  /// <summary>
  /// Konwerter koloru z/na łańcuch znaków
  /// </summary>
  public partial class PresetColorTypeConverter : ColorTypeConverter
  {

    /// <summary>
    /// Konwersja z postaci tekstowej
    /// </summary>
    public override object ConvertFrom (ITypeDescriptorContext context, CultureInfo culture, object value)
    {
      if (value is string)
      {
        string colorName = (string)value;
        System.Drawing.KnownColor knownColor;
        if (Enum.TryParse<System.Drawing.KnownColor>(colorName, out knownColor))
        {
          System.Drawing.Color temp = System.Drawing.Color.FromKnownColor(knownColor);
          PresetColor result = new PresetColor { Name = colorName, A = temp.A, R = temp.R, G = temp.G, B = temp.B };
          return result;
        }
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
      if (destinationType == typeof(string) && value is PresetColor)
      {
        PresetColor val = (PresetColor)value;
        return val.Name;
      }
      return base.ConvertTo(context, culture, value, destinationType);
    }
  }

}

using Iml.Documentation.Colors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  [TypeConverter(typeof(ColorTypeConverter))]
  public partial class Color
  {
    /// <summary>
    /// Podaje kolor w postaci nazwy lub liczby szesnastkowej
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      KeyValuePair<string, Color> kvp = Color.KnownColors.FirstOrDefault(item => item.Value.Equals(this));
      if (kvp.Key != null)
        return kvp.Key.ToLower();
      if (this.A == 0xFF)
        return (this.ToArgb() & 0xFFFFFF).ToString("X6");
      else
        return this.ToArgb().ToString("X8");
    }

    /// <summary>
    /// Konwersja z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static Color Parse (string s)
    {
      Color result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid Color string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out Color result)
    {
      if (Color.KnownColors.TryGetValue(s, out result))
      {
        return true;
      }

      string hexString = s;
      if (hexString.Length == 6)
        hexString = "FF" + hexString;
      if (hexString.Length == 8)
      {
        int hexValue;
        if (int.TryParse(hexString, NumberStyles.HexNumber, CultureInfo.InvariantCulture, out hexValue))
        {
          result = Color.FromArgb(hexValue);
          return true;
        }
      }
      result = null;
      return false;
    }
  }

  /// <summary>
  /// Konwerter koloru z/na łańcuch znaków
  /// </summary>
  public partial class ColorTypeConverter : TypeConverter
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
        TransformedColor tColor;
        if (TransformedColor.TryParse(s, out tColor))
          return tColor;

        ARGBColor realColor;
        if (ARGBColor.TryParse(s, out realColor))
          return realColor;

        HlsColor hlsColor;
        if (HlsColor.TryParse(s, out hlsColor))
          return hlsColor;

        Color color;
        if (Color.TryParse(s, out color))
          return color;

        SchemeColor schemeColor;
        if (SchemeColor.TryParse(s, out schemeColor))
          return schemeColor;

        SystemColor systemColor;
        if (SystemColor.TryParse(s, out systemColor))
          return systemColor;

        return null;
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

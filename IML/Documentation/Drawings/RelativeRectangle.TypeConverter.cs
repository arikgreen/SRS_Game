using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  [TypeConverter(typeof(RelativeRectangleTypeConverter))]
  public partial class RelativeRectangle
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      if (Left != null)
        sb.Append("Left=" + Left.ToString());
      if (Top != null)
      {
        if (sb.Length != 0)
          sb.Append(";");
        sb.Append("Top=" + Top.ToString());
      }
      if (Right != null)
      {
        if (sb.Length != 0)
          sb.Append(";");
        sb.Append("Right=" + Right.ToString());
      }
      if (Bottom != null)
      {
        if (sb.Length != 0)
          sb.Append(";");
        sb.Append("Bottom=" + Bottom.ToString());
      }
      string s = sb.ToString();
      if (s == "")
        return "Empty";
      else
        return s;
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static RelativeRectangle Parse (string s)
    {
      RelativeRectangle result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid RelativeRectangle string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out RelativeRectangle result)
    {
      result = new RelativeRectangle();
      if (s == "")
        return true;
      if (String.Compare("Empty", s, true) == 0)
        return true;
      string[] ss = s.Split(';');
      foreach (string s1 in ss)
      {
        if (s1 == null)
          return false;
        string[] ss1 = s1.Split('=');
        if (ss1.Length != 2)
          return false;
        if (ss1[0] == null || ss1[1] == null)
          return false;

        string name = ss1[0].ToLowerInvariant();
        Percent val;
        if (!Percent.TryParse(ss1[1], out val))
          return false;
        if (name.StartsWith("l"))
          result.Left = val;
        else if (name.StartsWith("t"))
          result.Top = val;
        else if (name.StartsWith("r"))
          result.Right = val;
        else if (name.StartsWith("b"))
          result.Bottom = val;
      }
      return true;
    }

  }

  /// <summary>
  /// Konwerter koloru z/na łańcuch znaków
  /// </summary>
  public partial class RelativeRectangleTypeConverter : TypeConverter
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

        RelativeRectangle val;
        if (RelativeRectangle.TryParse(s, out val))
          return val;

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


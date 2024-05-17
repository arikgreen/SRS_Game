using Iml.Documentation.Drawings;
using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class HlsColor
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      sb.Append("H=" + Hue.ToString(CultureInfo.InvariantCulture) + ", ");
      sb.Append("L=" + Luminance.ToString(CultureInfo.InvariantCulture) + ", ");
      sb.Append("S=" + Saturation.ToString(CultureInfo.InvariantCulture));
      return sb.ToString();
    }

    /// <summary>
    /// Konwersja z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static HlsColor Parse (string s)
    {
      HlsColor result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid HlsColor string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out HlsColor result)
    {
      result = null;
      if (s != null)
      {
        Angle hue = null;
        Percent lum = null;
        Percent sat = null;
        string[] ss = s.Split(',');
        foreach (string s1 in ss)
        {
          string[] ss1 = s1.Trim().Split('=');
          if (ss1.Length != 2)
            return false;
          if (String.IsNullOrEmpty(ss1[0]))
            return false;
          if (ss1[0].Length > 3)
            return false;
          char ch = char.ToUpperInvariant(ss1[0].First());
          switch (ch)
          {
            case 'H':
              if (!Angle.TryParse(ss1[1], out hue))
                return false;
              break;
            case 'L':
              if (!Percent.TryParse(ss1[1], out lum))
                return false;
              break;
            case 'S':
              if (!Percent.TryParse(ss1[1], out sat))
                return false;
              break;
            default:
              return false;
          }
        }
        if (hue != null && lum != null && sat != null)
        {
          result = new HlsColor { Hue = hue, Luminance = lum, Saturation = sat };
          double R, G, B;
          Color.Hls2Rgb(result.Hue, result.Luminance, result.Saturation, out R, out G, out B);
          result.R = Color.Byte(R * 255);
          result.G = Color.Byte(G * 255);
          result.B = Color.Byte(B * 255);
          return true;
        }
      }
      return false;
    }
  }
}

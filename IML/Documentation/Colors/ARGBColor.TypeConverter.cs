using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ARGBColor
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      if (!double.IsNaN(Alpha))
      sb.Append("A=" + Alpha.ToString(CultureInfo.InvariantCulture)+", ");
      sb.Append("R=" + Red.ToString(CultureInfo.InvariantCulture)+", ");
      sb.Append("G=" + Green.ToString(CultureInfo.InvariantCulture) + ", ");
      sb.Append("B=" + Blue.ToString(CultureInfo.InvariantCulture));
      return sb.ToString();
    }
    
    /// <summary>
    /// Konwersja z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static ARGBColor Parse (string s)
    {
      ARGBColor result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid ARGBColor string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out ARGBColor result)
    {
      result = null;
      Percent A = null;
      Percent R = null;
      Percent G = null;
      Percent B = null;
      if (s != null)
      {
        string[] ss = s.Split(',');
        foreach (string s1 in ss)
        {
          string[] ss1 = s1.Trim().Split('=');
          if (ss1.Length != 2)
            return false;
          if (String.IsNullOrEmpty(ss1[0]))
            return false; 
          Percent val;
          if (!Percent.TryParse(ss1[1], out val))
            return false;
          char ch = char.ToUpperInvariant(ss1[0].First());
          switch (ch)
          {
            case 'A':
              A = val;
              break;
            case 'R':
              R = val;
              break;
            case 'G':
              G = val;
              break;
            case 'B':
              B = val;
              break;
            default:
              return false;
          }
        }
        if (R!=null && G!=null && B!=null)
        {
          result = new ARGBColor { Alpha = A, Red = R, Blue = B, Green = G };
          if (A!=null)
            result.A = Color.Byte(result.Alpha * 255);
          result.R = Color.Byte(result.Red * 255);
          result.G = Color.Byte(result.Green * 255);
          result.B = Color.Byte(result.Blue * 255);
        }
        return true;
      }
      return false;
    }
  }
}

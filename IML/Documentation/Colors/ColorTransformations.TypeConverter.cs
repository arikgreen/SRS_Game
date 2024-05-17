using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ColorTransformations
  {
    /// <summary>
    /// Wykonanie wszystkich przekształceń na kolorze.
    /// </summary>
    /// <param name="source">kolor źródłowy</param>
    /// <returns>kolor wynikowy</returns>
    public Color Transform (Color source)
    {
      // Przekształcenia są wykonywane na tymczasowym kolorze rzeczywistym
      ARGBColor value = new ARGBColor { Alpha = source.A / 255.0, Red = source.R / 255.0, Green = source.G / 255.0, Blue = source.B / 255.0 };
      foreach (ColorTransformation transformation in this)
      {
        value = transformation.Transform(value);
      }
      return Color.FromArgb(Color.Byte(value.Alpha / 255), Color.Byte(value.Red / 255), 
        Color.Byte(value.Green / 255), Color.Byte(value.Blue / 255));
    }

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      int i = 0;
      foreach (ColorTransformation transformation in this)
      {
        if (i++ != 0)
          sb.Append("=>");
        sb.Append(transformation.ToString());
      }
      return sb.ToString();
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static ColorTransformations Parse (string s)
    {
      ColorTransformations result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid ColorTransformations string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out ColorTransformations result)
    {
      result = new ColorTransformations();
      if (s != null)
      {
        int m = s.IndexOf("=>");
        if (m <= 0)
          m = s.Length;
        int n = 0;
        while (m > 0)
        {
          ColorTransformation transformation;
          if (!ColorTransformation.TryParse(s.Substring(n,m-n), out transformation))
            return false;
          result.Add(transformation);
          n = m + 2;
          if (n>s.Length)
            break;
          m = s.IndexOf("=>",n);
          if (m < 0)
            m = s.Length;
        }
        return true;
      }
      return false;
    }
  }
}

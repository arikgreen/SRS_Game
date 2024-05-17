using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class TransformedColor
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      if (BaseColor != null)
        sb.Append(BaseColor.ToString());
      sb.Append("=>");
      if (Transformations != null)
        sb.Append(Transformations.ToString());
      return sb.ToString();
    }

    /// <summary>
    /// Konwersja z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static TransformedColor Parse (string s)
    {
      TransformedColor result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid TransformedColor string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out TransformedColor result)
    {
      result = null;
      if (s != null)
      {
        int k = s.IndexOf("=>");
        if (k < 0)
          return false;
        if (k > 0)
        {
          result = new TransformedColor();
          ColorTypeConverter converter = new ColorTypeConverter();
          result.BaseColor = converter.ConvertFromString(s.Substring(0, k)) as Color;
          if (result.BaseColor == null)
            return false;
        }
        else
          return false;
        k += 2;
        if (k < s.Length)
        {
          ColorTransformations transformations;
          if (ColorTransformations.TryParse(s.Substring(k), out transformations))
            result.Transformations = transformations;
          else
            return false;
        }
        return true;
      }
      return false;
    }
  }
}

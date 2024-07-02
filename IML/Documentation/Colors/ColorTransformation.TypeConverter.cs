using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ColorTransformation
  {
    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static ColorTransformation Parse (string s)
    {
      ColorTransformation result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid ColorTransformation string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out ColorTransformation result)
    {
      result = null;
      if (s != null)
      {
        int k = s.IndexOf('(');
        if (k > 0)
        {
          string name = s.Substring(0, k).ToLowerInvariant();
          s = s.Substring(k + 1, s.Length - k - 2);
          Percent val = null;
          if (!String.IsNullOrEmpty(s))
          {
            if (!Percent.TryParse(s, out val))
              return false;
          }
          if (name == "tint")
          {
            if (val == null)
              return false;
            result = new TintTransformation { Value = val };
            return true;
          }
          else if (name == "shade")
          {
            if (double.IsNaN(val))
              return false;
            result = new ShadeTransformation { Value = val };
            return true;
          }
          else if (name == "gamma")
          {
            if (double.IsNaN(val))
              return false;
            result = new GammaTransformation { Value = val };
            return true;
          }
          else if (name == "gray")
          {
            result = new GrayTransformation();
            return true;
          }
          else if (name == "inverse")
          {
            result = new InverseTransformation();
            return true;
          }
          else if (name == "complement")
          {
            result = new ComplementTransformation();
            return true;
          }
        }
        else
        {
          k = s.IndexOf('=');
          if (k > 0)
          {
            ScaleColorMember scaleTransformation;
            if (ScaleColorMember.TryParse(s, out scaleTransformation))
            {
              result = scaleTransformation;
              return true;
            }

            ShiftColorMember shiftTransformation;
            if (ShiftColorMember.TryParse(s, out shiftTransformation))
            {
              result = shiftTransformation;
              return true;
            }

            SetColorMember setTransformation;
            if (SetColorMember.TryParse(s, out setTransformation))
            {
              result = setTransformation;
              return true;
            }

          }
        }
      }
      return false;
    }

  }
}

using Iml.Documentation.Drawings;
using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class SetColorMember
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      if (Member == ColorMembers.Hue)
        return this.Member.ToString() + "=" + this.Angle.ToString(System.Globalization.CultureInfo.InvariantCulture);
      else
        return this.Member.ToString() + "=" + this.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static SetColorMember Parse (string s)
    {
      SetColorMember result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid SetColorMember string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out SetColorMember result)
    {
      result = null;
      if (s != null)
      {
        int k = s.IndexOf("=");
        if (k > 0)
        {
          string name = s.Substring(0, k).ToLowerInvariant();
          ColorMembers member;
          if (Enum.TryParse<ColorMembers>(name, true, out member))
          {
            result = new SetColorMember();
            result.Member = member;
            k += 1;
            s = s.Substring(k, s.Length - k);
            Percent val;
            if (Percent.TryParse(s, out val))
            {
              result.Value = val;
              return true;
            }
            Angle angle;
            if (Angle.TryParse(s, out angle))
            {
              result.Angle = angle;
              return true;
            }
            return false;
          }
        }
      }
      return false;
    }
  }
}

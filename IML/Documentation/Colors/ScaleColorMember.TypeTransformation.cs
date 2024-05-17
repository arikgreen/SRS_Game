using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ScaleColorMember
  {

    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return this.Member.ToString() + "*=" + this.Value.ToString(System.Globalization.CultureInfo.InvariantCulture);
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static ScaleColorMember Parse (string s)
    {
      ScaleColorMember result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid ScaleColorMember string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out ScaleColorMember result)
    {
      result = null;
      if (s != null)
      {
        int k = s.IndexOf("*=");
        if (k > 0)
        {
          string name = s.Substring(0, k).ToLowerInvariant();
          ColorMembers member;
          if (Enum.TryParse<ColorMembers>(name, true, out member))
          {
            result = new ScaleColorMember();
            result.Member = member;
            k += 2;
            s = s.Substring(k, s.Length - k);
            Iml.Foundation.Percent val;
            if (!Percent.TryParse(s, out val))
              return false;
            result.Value = val;
            return true;
          }
        }
      }
      return false;
    }
  }
}


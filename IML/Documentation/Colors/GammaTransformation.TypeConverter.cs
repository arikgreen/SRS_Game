using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class GammaTransformation
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return "Gamma(" + this.Value.ToString(System.Globalization.CultureInfo.InvariantCulture) + ")";
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static GammaTransformation Parse (string s)
    {
      GammaTransformation result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid GammaTransformation string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out GammaTransformation result)
    {
      result = null;
      if (s != null)
      {
        int k = s.IndexOf('(');
        if (k > 0)
        {
          string name = s.Substring(0, k).ToLowerInvariant();
          if (name == "gamma")
          {
            result = new GammaTransformation();
            s = s.Substring(k + 1, s.Length - k - 2);
            Percent val;
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class GrayTransformation
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return "Gray()";
    }


    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static GrayTransformation Parse (string s)
    {
      GrayTransformation result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid GrayTransformation string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out GrayTransformation result)
    {
      result = null;
      if (s != null)
      {
        int k = s.IndexOf('(');
        if (k > 0)
        {
          string name = s.Substring(0, k).ToLowerInvariant();
          if (name == "gray")
          {
            result = new GrayTransformation();
            return true;
          }
        }
      }
      return false;
    }
  }
}


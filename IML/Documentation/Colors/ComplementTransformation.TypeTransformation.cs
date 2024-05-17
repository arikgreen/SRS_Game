using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Colors
{
  public partial class ComplementTransformation
  {
    /// <summary>
    /// Konwersja na łańcuch
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return "Complement()";
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static ComplementTransformation Parse (string s)
    {
      ComplementTransformation result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid Complement string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out ComplementTransformation result)
    {
      result = null;
      if (s != null)
      {
        int k = s.IndexOf('(');
        if (k > 0)
        {
          string name = s.Substring(0, k).ToLowerInvariant();
          if (name == "complement")
          {
            result = new ComplementTransformation();
            return true;
          }
        }
      }
      return false;
    }

  }
}

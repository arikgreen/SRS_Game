using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Brak wypełnienia
  /// </summary>
  public partial class NoFill : Fill
  {
    /// <summary>
    /// Czy może być serializowane do łańcucha
    /// </summary>
    /// <returns></returns>
    public override bool CanSerializeToString ()
    {
      return true;
    }

    /// <summary>
    /// Napisem wynikowym jest "NoFill"
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      return "NoFill";
    }

    /// <summary>
    /// Konwersja z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static NoFill Parse (string s)
    {
      NoFill result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid NoFill string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha 
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out NoFill result)
    {
      if (String.Compare(s, "NoFill", true) == 0)
      {
        result = new NoFill();
        return true;
      }
      result = null;
      return false;
    }

  }
}

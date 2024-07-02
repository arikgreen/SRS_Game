using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  public partial class Rectangle
  {
    /// <summary>
    /// Konwersja na łańcuch wszystkich trzech współrzędnych
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      StringBuilder sb = new StringBuilder();
      if (Left != null)
        sb.Append("Left=" + Left.ToString());
      if (Top != null)
      {
        if (sb.Length != 0)
          sb.Append(";");
        sb.Append("Top=" + Top.ToString());
      }
      if (Right != null)
      {
        if (sb.Length != 0)
          sb.Append(";");
        sb.Append("Right=" + Right.ToString());
      }
      if (Bottom != null)
      {
        if (sb.Length != 0)
          sb.Append(";");
        sb.Append("Bottom=" + Bottom.ToString());
      }
      return sb.ToString();
    }

    /// <summary>
    /// Konwersja z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public static Rectangle Parse (string s)
    {
      Rectangle result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid Rectangle string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out Rectangle result)
    {
      result = new Rectangle();
      if (s == "")
        return true;
      string[] ss = s.Split(';');
      foreach (string s1 in ss)
      {
        if (s1 == null)
          return false;
        string[] ss1 = s1.Split('=');
        if (ss1.Length != 2)
          return false;
        if (ss1[0] == null || ss1[1] == null)
          return false;

        string name = ss1[0].ToLowerInvariant();
        PointValue val;
        if (!PointValue.TryParse(ss1[1], out val))
          return false;
        if (name.StartsWith("l"))
          result.Left = val;
        else if (name.StartsWith("t"))
          result.Top = val;
        else if (name.StartsWith("r"))
          result.Right = val;
        else if (name.StartsWith("b"))
          result.Bottom = val;
      }
      return true;
    }

  }
}

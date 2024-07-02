using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class SystemColor
  {
    /// <summary>
    /// Podaje kolor w postaci nazwy
    /// </summary>
    /// <returns></returns>
    public override string ToString ()
    {
      if (Value != 0)
        return string.Format("{0}={1}", Name, base.ToString());
      else
        return Name;
    }

    /// <summary>
    /// Konwersja z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <returns></returns>
    public new static SystemColor Parse (string s)
    {
      SystemColor result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid SystemColor string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out SystemColor result)
    {
      if (s != null)
      {
        string[] ss = s.Split('=');
        if (ss.Length > 0)
        {
          string colorName = ss[0]; System.Drawing.KnownColor knownColor;
          if (Enum.TryParse<System.Drawing.KnownColor>(colorName, out knownColor))
          {
            System.Drawing.Color sysColor = System.Drawing.Color.FromKnownColor(knownColor);
            result = new SystemColor { Name = colorName, A = sysColor.A, R = sysColor.R, G = sysColor.G, B = sysColor.B };
            if (ss.Length > 1)
            {
              Color temp;
              if (Color.TryParse(ss[1], out temp))
                result.Value = temp.Value;
            }
            return true;
          }
        }
      }
      result = null;
      return false;
    }
  }
}

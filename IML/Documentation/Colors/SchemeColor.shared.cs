using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class SchemeColor
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
    public new static SchemeColor Parse (string s)
    {
      SchemeColor result;
      if (TryParse(s, out result))
        return result;
      throw new FormatException("Invalid SchemeColor string format");
    }

    /// <summary>
    /// Próba konwersji z łańcucha na kolor
    /// </summary>
    /// <param name="s"></param>
    /// <param name="result"></param>
    /// <returns></returns>
    public static bool TryParse (string s, out SchemeColor result)
    {
      if (s != null)
      {
        string[] ss = s.Split('=');
        if (ss.Length > 0)
        {
          string colorName = ss[0];
          if (SchemeColorNames.Contains(colorName))
          {
            result = new SchemeColor { Name = colorName };
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

    /// <summary>
    /// Lista rozpoznawanych nazw kolorów w schemacie
    /// </summary>
    public static List<string> SchemeColorNames = new List<string>
    {
      "Accent1",
      "Accent2",
      "Accent3",
      "Accent4",
      "Accent5",
      "Accent6",
      "BackgroundColor",
      "BackgroundAltColor",
      "Dark1",
      "Dark2",
      "FollowedHyperlink",
      "Hyperlink",
      "Light1",
      "Light2",
      "StyleColor",
      "TextColor",
      "TextAltColor",
    };
  }
}

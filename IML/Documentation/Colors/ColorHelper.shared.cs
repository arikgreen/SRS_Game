using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Iml.Documentation
{
  /// <summary>
  /// Klasa pomocnicza realizująca operacje na kolorach
  /// </summary>
  public static class ColorHelper
  {
    /// <summary>
    /// Konwersja łańcucha na kolor
    /// </summary>
    /// <param name="str"></param>
    public static Color ColorFromString (string str)
    {
      if (String.IsNullOrEmpty (str))
        return Color.FromArgb (0, 0, 0, 0);
      if (str[0] == '#')
      {
        if (str.Length == 9 || str.Length == 7)
        {
          byte B;
          if (byte.TryParse (str.Substring (str.Length - 2, 2), out B))
          {
            byte G;
            if (byte.TryParse (str.Substring (str.Length - 4, 2), out G))
            {
              byte R;
              if (byte.TryParse (str.Substring (str.Length - 6, 2), out R))
              {
                byte A = 0xFF;
                if (str.Length == 7 || byte.TryParse (str.Substring (str.Length - 8, 2), out A))
                  return Color.FromArgb (A, R, G, B);
              }
            }
          }
        }
      }
      throw new NotImplementedException ("Not supported color value = " + str);
    }

    /// <summary>
    /// Konwersja z koloru na łańcuch
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ColorToString (Color value)
    {
      if (value.A == 0 && value.R == 0 && value.G == 0 && value.B == 0)
        return null;
      return "#" + value.A.ToString ("X2") + value.R.ToString ("X2") + value.G.ToString ("X2") + value.B.ToString ("X2");
    }

    /// <summary>
    /// Sumowanie kolorów
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <returns></returns>
    public static Color Add (Color X, Color Y)
    {
      return Color.FromArgb ((byte)(X.A | Y.A), (byte)(X.R | Y.R), (byte)(X.G | Y.G), (byte)(X.B | Y.B));
    }

    /// <summary>
    /// Sumowanie kolorów przekazywanych w postaci tekstowej
    /// </summary>
    /// <param name="X"></param>
    /// <param name="Y"></param>
    /// <returns></returns>
    public static string Add (string X, string Y)
    {
      return ColorToString (Add (ColorFromString (X), ColorFromString (Y)));
    }
  }
}

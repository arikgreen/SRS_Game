using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa pomocnicza tworząca unikatowy identyfikator referencyjny dla podanego prefiksu
  /// </summary>
  public partial class RefIDGenerator
  {
    /// <summary>
    /// Sprawdzenie, czy podany łańcuch jest poprawnym identyfikatorem referencyjnym.
    /// Poprawny RefID składa się z dwóch części oddzielonych znakiem podkreślenia.
    /// Część pierwsza składa się z samych wielkich liter,
    /// a część druga z samych cyfr.
    /// </summary>
    public static bool IsRefID (string value)
    {
      string[] ss = value.Split ('_');
      if (ss.Length != 2)
        return false;
      foreach (char ch in ss[0])
        if (!Char.IsUpper (ch))
          return false;
      foreach (char ch in ss[1])
        if (!Char.IsDigit (ch))
          return false;
      return true;
    }

    /// <summary>
    /// Numery ostatnio użytych identyfikatorów wg prefiksów
    /// </summary>
    private SortedList<string, int> IDsByPrefix = new SortedList<string, int> ();

    /// <summary>
    ///  Funkcja podająca unikatowy identyfikator RefID dla podanego prefiksu.
    /// </summary>
    public string NewID (string prefix)
    {
      int n;
      if (IDsByPrefix.TryGetValue (prefix, out n))
      {
        n++;
        IDsByPrefix[prefix] = n;
      }
      else
      {
        n = 1;
        IDsByPrefix.Add (prefix, n);
      }
      return prefix + "_" + String.Format ("{0:D5}", n);
    }
  }
}

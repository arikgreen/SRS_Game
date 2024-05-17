using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{

  /// <summary>
  /// Zakładki wykryte w tekście
  /// </summary>
  partial class Bookmarks: Dictionary<string, Bookmark>
  {

    /// <summary>
    /// Dodanie zakładki do listy
    /// </summary>
    /// <param name="aBookmark">zakładka dodawana</param>
    public void Add(Bookmark aBookmark)
    {
      this.Add(aBookmark.Name, aBookmark);
    }

    /// <summary>
    /// Znalezienie zakładek dla określonego akapitu.
    /// </summary>
    /// <param name="aDestination">akapit, który ma być wskazywany przez zakładki</param>
    /// <returns>lista zakładek (może być pusta)</returns>
    public Bookmark[] FindBookmarksFor(Paragraph aDestination)
    {
      var bookmarks = (from item in Values where item.Target == aDestination select item);
      return bookmarks.ToArray<Bookmark>();
    }
  }



}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;
using IML = Iml.Documentation;

namespace Iml.Documentation
{

  /// <summary>
  /// Kolekcja zakładek występujących w tekście
  /// </summary>
  public partial class Bookmarks: ItemIndex<BookmarkBegin>
  {

    /// <summary> Nieprzetestowane
    /// Dodanie zakładki do listy
    /// </summary>
    /// <param name="aBookmark">zakładka dodawana</param>
    public override void Add(BookmarkBegin aBookmark)
    {
      this.Add(aBookmark.Id, aBookmark);
    }

    ///// <summary> Nieprzetestowane
    ///// Znalezienie zakładek dla określonego akapitu.
    ///// </summary>
    ///// <param name="aDestination">akapit, który ma być wskazywany przez zakładki</param>
    ///// <returns>lista zakładek (może być pusta)</returns>
    //public Bookmark[] FindBookmarksFor(IML.Paragraph aDestination)
    //{
    //  var bookmarks = (from item in Values where item.Destination == aDestination select item);
    //  return bookmarks.ToArray<Bookmark>();
    //}
  }

}


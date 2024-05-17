using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Kolekcja czcionek
  /// </summary>
  public partial class FontCollection: NamedItemIndex<Font>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public FontCollection () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public FontCollection (object owner) : base(owner) { }

    /// <summary>
    /// Dodawanie czcionki do indeksu
    /// </summary>
    /// <param name="item"></param>
    public override void Add (Font item)
    {
      Add(item.Script, item);
    }
  }
}

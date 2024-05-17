using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Kolekcja wszystkich tekstów we fragmencie tekstu
  /// </summary>
  public partial class TextItems: ContentList
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TextItems () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public TextItems (Item owner) : base(owner) { }
  }
}

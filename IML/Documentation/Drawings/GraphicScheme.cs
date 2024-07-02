using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Kolekcja stylów graficznych
  /// </summary>
  public partial class GraphicScheme: NamedItemIndex<GraphicStyle>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public GraphicScheme () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public GraphicScheme (object owner) : base(owner) { }

    /// <summary>
    /// Dodawanie elementu do indeksu
    /// </summary>
    /// <param name="item"></param>
    public override void Add (GraphicStyle item)
    {
      Add(item.Id, item);
    }
  }
}

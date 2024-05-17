using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista kolumn tekstowych (szpalt)
  /// </summary>
  public partial class TextColumns: ItemList<TextColumn>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TextColumns () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public TextColumns (object owner) : base(owner) { }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista nagłówków
  /// </summary>
  public partial class Footers: ItemList<Footer>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Footers () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    public Footers (object owner) : base(owner) { }
  }
}

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
  public partial class Headers : ItemList<Header>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Headers () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    public Headers (object owner) : base(owner) { }
  }
}

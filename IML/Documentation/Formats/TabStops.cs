using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{

  /// <summary>
  /// Tabulatory zdefiniowane w akapicie
  /// </summary>
  public partial class TabStops: ItemList<TabStop>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public TabStops () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public TabStops (object owner) : base(owner) { }
  }

}


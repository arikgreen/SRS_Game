using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Lista elementów listy wyboru
  /// </summary>
  public partial class Parameters : ItemList<Parameter>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Parameters () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Parameters (Item owner) : base(owner) { }

  }
}

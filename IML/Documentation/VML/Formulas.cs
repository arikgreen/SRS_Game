using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Lista formuł VML
  /// </summary>
  public partial class Formulas: Iml.Foundation.ItemList<Formula>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Formulas () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Formulas (VmlElement owner) : base(owner) { }
  }
}

using Iml.Foundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Lista efektów graficznych
  /// </summary>
  public partial class EffectList: ItemList<Effect>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public EffectList () { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public EffectList (object owner) : base(owner) { }
  }
}

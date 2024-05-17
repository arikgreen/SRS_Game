using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Modeling
{
  /// <summary>
  /// Lista typów modelu
  /// </summary>
  public partial class Types : ObjectList<Type>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Types () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Types (object owner) : base(owner) { }
  }
}

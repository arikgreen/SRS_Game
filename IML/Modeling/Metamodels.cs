using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Modeling
{
  /// <summary>
  /// Lista metamodeli
  /// </summary>
  public partial class Metamodels: ObjectList<Metamodel>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Metamodels () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Metamodels (object owner) : base(owner) { }
  }
}

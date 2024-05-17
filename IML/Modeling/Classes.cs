using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Modeling
{
  /// <summary>
  /// Lista metaklas
  /// </summary>
  public partial class Classes : ObjectList<Class>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Classes () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Classes (object owner) : base(owner) { }
  }
}

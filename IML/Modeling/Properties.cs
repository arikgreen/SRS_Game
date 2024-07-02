using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Modeling
{
  /// <summary>
  /// Lista właściwości klasy
  /// </summary>
  public partial class Properties : ObjectList<Property>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Properties () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public Properties (object owner) : base(owner) { }
  }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Modeling
{
  /// <summary>
  /// Lista wartości typu wyliczanego
  /// </summary>
  public partial class EnumValues : ObjectList<EnumValue>
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public EnumValues () : base() { }

    /// <summary>
    /// Konstruktor z właścicielem
    /// </summary>
    /// <param name="owner"></param>
    public EnumValues (object owner) : base(owner) { }
  }
}

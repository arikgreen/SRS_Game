using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Abstrakcyjny obiekt zewnętrzny wobec systemu.
  /// Zalicza się tu użytkowników i systemy zewnętrzne
  /// </summary>
  [Metaclass(Order = "3.1")]
  [IsAbstract]
  [KnownType(typeof(User))]
  [KnownType(typeof(ExternalSystem))]
  public class ExternalObject : ActiveObject
  {
  }
}

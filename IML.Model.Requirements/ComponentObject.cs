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
  /// Abstrakcyjny obiekt wewnętrzny systemu. 
  /// Zalicza się tu system
  /// </summary>
  [Metaclass(Order="3.2")]
  [IsAbstract]
  [KnownType(typeof(Subsystem))]
  [KnownType(typeof(SystemComponent))]
  public class ComponentObject: ActiveObject
  {
  }
}

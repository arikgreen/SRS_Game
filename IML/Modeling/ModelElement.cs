using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iml.Foundation;

namespace Iml.Modeling
{
  /// <summary>
  /// Abstrakcyjna klasa elementu modelowego
  /// </summary>
  [Metaclass]
  [IsAbstract]
  //[CanContain(typeof(ModelElement), Semantics = "ownedElement", Union = true)]
  [CanBelongTo(typeof(ModelElement), Semantics = "owner", Union = true)]
  public partial class ModelElement: SemanticElement
  {
  }
}

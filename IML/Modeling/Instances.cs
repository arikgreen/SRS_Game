using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Wartość instancji
  /// </summary>
  [CanReferTo(typeof(InstanceSpecification), Semantics = "instance", Multiplicity="1")]
  public partial class InstanceValue: ValueSpecification
  {
  }

  /// <summary>
  /// Specyfikacja instancji
  /// </summary>
  [CanContain(typeof(Slot), Semantics = "slot", BackwardSemantics = "owningInstance", 
    Subsets="ownedElement")]
  [CanContain(typeof(ValueSpecification), Semantics = "specification", BackwardSemantics = "owningInstanceSpec", 
    Subsets = "ownedElement", Multiplicity="0..1")]
  [CanReferTo(typeof(Classifier), Semantics = "classifier")]
  public partial class InstanceSpecification : NamedElement
  {
  }

  /// <summary>
  /// Miejsce na instancję
  /// </summary>
  [CanBelongTo(typeof(InstanceSpecification), Semantics = "owningInstance", BackwardSemantics = "slot", 
    Subsets = "owner", Required = true)]
  [CanContain(typeof(ValueSpecification), Semantics = "value", BackwardSemantics = "owningSlot",
    Subsets = "ownedElement", Ordered = true)]
  [CanReferTo(typeof(StructuralFeature), Semantics = "definingFeature", Required = true, Multiplicity = "1")]
  public partial class Slot : ModelElement
  {
  }

  [CanBelongTo(typeof(InstanceSpecification), Semantics = "owningInstanceSpec", BackwardSemantics = "specification",
    Subsets = "owner")]
  [CanBelongTo(typeof(Slot), Semantics = "owningSlot", BackwardSemantics = "value",
    Subsets = "owner")]
  public partial class ValueSpecification
  {
  }
}

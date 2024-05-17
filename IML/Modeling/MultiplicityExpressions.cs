using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  [CanContain(typeof(ValueSpecification), 
    Semantics = "upperValue", 
    BackwardSemantics = "owningUpper",
    Subsets = "ownedElement",
    Multiplicity="0..1")]
  [CanContain(typeof(ValueSpecification),
    Semantics = "lowerValue",
    BackwardSemantics = "owningLower",
    Subsets = "ownedElement",
    Multiplicity = "0..1")]
  public abstract partial class MultiplicityElement
  {
  }

  [CanBelongTo(typeof(MultiplicityElement),
    Semantics = "owningUpper",
    BackwardSemantics = "upperValue",
    Subsets = "owner")]
  [CanBelongTo(typeof(MultiplicityElement),
    Semantics = "owningLower",
    BackwardSemantics = "lowerValue",
    Subsets = "owner")]
  public abstract partial class ValueSpecification
  {
  }
}

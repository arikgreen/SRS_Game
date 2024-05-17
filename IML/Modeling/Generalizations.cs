using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Klasyfikator
  /// </summary>
  [CanReferTo(typeof(Classifier), Semantics = "general")]
  [CanContain(typeof(Generalization), 
    Semantics = "generalization", BackwardSemantics = "specific", Subsets="ownedElement")]
  public abstract partial class Classifier
  {
  }

  /// <summary>
  /// Relacja dziedziczenia
  /// </summary>
  [CanBelongTo(typeof(Classifier), Required=true, 
    Semantics="specific", BackwardSemantics="generalization", Subsets="source, owner")]
  [CanReferTo(typeof(Classifier), Semantics="general", Subsets="target")]
  public partial class Generalization: DirectedRelationship
  {
  }
}

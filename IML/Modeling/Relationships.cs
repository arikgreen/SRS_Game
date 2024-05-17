using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Relacja między elementami projektu
  /// </summary>
  [CanReferTo(typeof(ModelElement), Required = true,
    Semantics = "relatedElement", Readonly = true, Union = true)]
  public partial class Relationship: Iml.Modeling.ModelElement
  {
  }

  /// <summary>
  /// Relacja skierowana
  /// </summary>
  [CanReferTo(typeof(ModelElement), Required = true,
    Semantics = "source", Subsets = "relatedElement", Readonly = true, Union = true)]
  [CanReferTo(typeof(ModelElement), Required = true,
    Semantics = "target", Subsets = "relatedElement", Readonly = true, Union = true)]
  public partial class DirectedRelationship : Relationship
  {
  }

}

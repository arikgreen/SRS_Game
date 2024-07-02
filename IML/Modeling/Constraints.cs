using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  /// <summary>
  /// Zastrzeżenie przypisywane do elementu
  /// </summary>
  [CanReferTo(typeof(ModelElement), Semantics = "constraintElement", Ordered = true)]
  [CanBelongTo(typeof(INamespace), Semantics = "context", Subsets = "namespace")]
  public partial class Constraint: NamedElement
  {
  }

  [CanContain(typeof(Constraint), Semantics = "ownedRule", Subsets = "ownerMember")]
  public partial interface INamespace
  {
  }

}

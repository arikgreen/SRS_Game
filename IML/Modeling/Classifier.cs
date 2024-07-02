using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;

  [CanReferTo(typeof(Classifier), Semantics="general")]
  [CanReferTo(typeof(NamedElement), Semantics="inheritedMember", Readonly = true, Subsets = "member")]
  public abstract partial class Classifier
  {
    /// <summary>
    /// Czy klasyfikator jest abstrakcyjny
    /// </summary>
    public bool IsAbstract { get; set; }
  }
}

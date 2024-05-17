using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Modeling
{
  using Iml.Foundation;


  /// <summary>
  /// Abstrakcyjna cecha behawioralna
  /// </summary>
  [CanReferTo(typeof(Parameter), Semantics="parameter",
    Ordered=true, Subsets="member", Union=true)]
  public abstract class BehavioralFeature : Feature, INamespace
  {
  }

  /// <summary>
  /// Parameter cechy behawioralnej
  /// </summary>
  public partial class Parameter : NamedElement, ITypedElement
  {
  }
}

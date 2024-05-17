using System.Collections.Generic;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Cel biznesowy projektu
  /// </summary>
  [Metaclass(Order="2.1")]
  [CanContain(typeof(Motivation), GroupName = "advantages", Stereotype = "advantage")]
  [CanContain(typeof(Motivation), GroupName="advantages", Stereotype="problem")]
  public class Goal : Objective
  {
    /// <summary>
    /// Korzyści, które można osiągnąć; problemy, które można rozwiązać.
    /// </summary>
    [MetaclassProperty]
    public Motivation[] Motivations
    {
      get
      {
        List<SemanticElement> result;
        if (TryGetItems(typeof(Motivation), out result))
          return (result.ToArray() as Motivation[]);
        else
          return new Motivation[0];
      }
    }
  }
}

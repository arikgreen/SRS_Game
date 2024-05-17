using System.Collections.Generic;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Klasa reprezentująca podsystem. Podsystem może zawierać inne podsystemy
  /// oraz komponenty programowe i sprzętowe.
  /// </summary>
  [Metaclass(Order = "3.2.1")]
  public class Subsystem : ComponentObject
  {
    /// <summary>
    /// komponenty składowe podsystemu; mogą to być inne podsystemy, komponenty programowe albo sprzętowe
    /// </summary>
    [MetaclassProperty]
    public new ComponentObject[] Components
    {
      get
      {
        List<SemanticElement> result;
        if (TryGetItems(typeof(Motivation), out result))
          return (result.ToArray() as ComponentObject[]);
        else
          return new ComponentObject[0];
      }
    }
  }
}

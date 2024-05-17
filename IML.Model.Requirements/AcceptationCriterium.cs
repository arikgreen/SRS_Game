using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{


  /// <summary>
  /// Klasa reprezentująca kryterium akceptacyjne
  /// </summary>
  [Metaclass(Order="5")]
  [CanReferTo(typeof(Requirement), Semantics="appliesTo")]
  [CanReferTo(typeof(Objective), Semantics = "appliesTo")]
  [CanReferTo(typeof(Source), Semantics = "appliesTo", Allowed = false)]
  public class AcceptationCriterium : RequirementsElement
  {
  }
}

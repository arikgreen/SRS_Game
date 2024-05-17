using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Klasa reprezentująca wymaganie funkcjonalne
  /// </summary>
  [Metaclass(Order = "4.1")]
  [CanReferTo(typeof(ActiveObject), Semantics = "appliesTo", Required = true)]
  [CanReferTo(typeof(Motivation), Semantics = "appliesTo")]
  [Foundation(typeof(Objective))]
  [Foundation(typeof(ExceptionHandling))]
  public class FunctionalRequirement : Requirement
  {
  }
}

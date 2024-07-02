using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Klasa reprezentująca wymaganie na oprogramowanie
  /// </summary>
  [Metaclass(Order = "4.6")]
  [CanReferTo(typeof(SoftwareComponent), Semantics = "appliesTo")]
  public class SoftwareRequirement : Requirement
  {
  }
}

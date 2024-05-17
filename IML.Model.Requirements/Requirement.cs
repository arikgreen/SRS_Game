using System.Runtime.Serialization;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Abstrakcyjna klasa reprezentująca wymaganie. 
  /// </summary>
  [Metaclass(Order="4")]
  [IsAbstract]
  [KnownType(typeof(FunctionalRequirement))]
  [KnownType(typeof(DataRequirement))]
  [KnownType(typeof(QualityRequirement))]
  [KnownType(typeof(ExceptionHandling))]
  [KnownType(typeof(HardwareRequirement))]
  [KnownType(typeof(SoftwareRequirement))]
  [KnownType(typeof(ExtraRequirement))]
  public class Requirement : RequirementsElement
  {
  }
}

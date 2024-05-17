using System.Runtime.Serialization;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Abstrakcyjna klasa celu projektu. Dzieli się na cele biznesowe (<see cref="Goal"/>)
  /// i cele funkcjonalne (<see cref="Purpose"/>)
  /// </summary>
  [Metaclass(Order="2")]
  [KnownType(typeof(Goal))]
  [KnownType(typeof(Purpose))]
  [Outcome(typeof(FunctionalRequirement))]
  [IsAbstract]
  public class Objective : RequirementsElement
  {
  }
}

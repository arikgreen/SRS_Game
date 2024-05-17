using System.Collections.Generic;
using System.Linq;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{

  /// <summary>
  /// Klasa reprezentująca sytuację wyjątkową.
  /// </summary>
  [Metaclass(Order = "4.4")]
  [CanReferTo(typeof(FunctionalRequirement), Semantics = "solution", GroupName = "solutions", Required = true)]
  [CanReferTo(typeof(QualityRequirement), Semantics="solution", GroupName="solutions")]
  [Property("ThreatLevel", Required=true)]
  [Outcome(typeof(FunctionalRequirement))]
  [Outcome(typeof(QualityRequirement))]
  public class ExceptionHandling : Requirement
  {
    /// <summary>
    /// Poziom zagrożenia
    /// </summary>
    [MetaclassProperty]
    public ThreatLevel Level { get; set; }

    /// <summary>
    /// Wymagania funkcjonalne, które umożliwiają rozwiązanie sytuacji wyjątkowej
    /// </summary>
    [MetaclassProperty]
    public FunctionalRequirement[] Solutions
    {
      get
      {
        List<Reference> result;
        if (TryGetReferences("solution", out result))
          return (from item in result
                  where item.Target != null && item.Target.GetType() == typeof(FunctionalRequirement)
                  select item.Target).ToArray() as FunctionalRequirement[];
        else
          return new FunctionalRequirement[0];
      }
    }
  }

  /// <summary>
  /// Poziomy zagrożeń
  /// </summary>
  [Metatype(Order = "0.2")]
  public enum ThreatLevel
  {
    /// <value>nieokreślony</value>
    unknown,
    /// <value>zakłócenie normalnego działania, nie powinno prowadzić do awarii</value>
    disturbance,
    /// <value>zagrożenie krytyczne, może doprowadzić do awarii</value>
    critical,
    /// <value>katastrofa - awaria już wystąpiła</value>
    catastrophic
  }
}

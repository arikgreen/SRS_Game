using System.ComponentModel;
using System.Xml.Serialization;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{

  /// <summary>
  /// Klasa reprezentująca wymaganie jakościowe
  /// </summary>
  [Metaclass(Order = "4.3")]
  [CanReferTo(typeof(DataRequirement), Semantics = "appliesTo")]
  [Property("Metric", Required = true)]
  public class QualityRequirement : Requirement
  {
    /// <summary>
    /// Metryka jakości, której dotyczy to wymaganie
    /// </summary>
    [MetaclassProperty]
    [XmlAttribute("Metric")]
    [DefaultValue(null)]
    public string Metric { get; set; }

  }
}

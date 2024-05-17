using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Podstawowa klasa elementu specyfikacji wymagań.
  /// Wszystkie elementy mają swój priorytet
  /// </summary>
  [Metaclass(Order="0")]
  [Property("Priority", Required=true, DisplayOrder=19)]
  [IsAbstract]
  public class RequirementsElement : ModelElement
  {
    /// <summary>
    /// konstruktor bezparametrowy
    /// </summary>
    public RequirementsElement ()
    {
    }

    /// <summary>
    /// Priorytet elementu specyfikacji wymagań.
    /// </summary>
    [MetaclassProperty]
    [XmlAttribute("Priority")]
    [DefaultValue(RequirementPriority.unspecified)]
    public RequirementPriority Priority { get; set; }    
  }

  /// <summary>
  /// Poziomy ważności wymagań.
  /// </summary>
  [Metatype(Order = "0.1")]
  public enum RequirementPriority
  {
    /// <value>
    /// nieustalony priorytet
    /// </value>
    unspecified = 0,

    /// <value>
    /// priorytet opcjonalny
    /// </value>
    optional = 1,

    /// <value>
    /// priorytet niski
    /// </value>
    low = 2,

    /// <value>
    /// priorytet średni
    /// </value>
    medium = 3,

    /// <value>
    /// priorytet wysoki
    /// </value>
    high = 4,

    /// <value>
    /// priorytet krytyczny
    /// </value>
    critical = 5
  }
}

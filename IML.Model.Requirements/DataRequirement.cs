using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Iml.Foundation;
using Iml.Modeling;

namespace Iml.Model.Requirements
{
  /// <summary>
  /// Klasa reprezentująca wymaganie na dane
  /// </summary>
  [Metaclass(Order = "4.2")]
  [CanContain(typeof(DataItem), GroupName="data")]
  public class DataRequirement : Requirement
  {

    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public DataRequirement()
    {
      Data = new SemanticQuery<DataItem>(this.Items, item => item is DataItem);
    }

    /// <summary>
    /// Dane, jakie muszą być zapamiętywane i przekazywane
    /// </summary>
    [MetaclassProperty]
    [IgnoreDataMember]
    [XmlIgnore]
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public SemanticQuery<DataItem> Data { get; set; }
  }
}

using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Xml.Serialization;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Element historii dokumentu. 
  /// Pokazuje jakie zmiany zostały wprowadzone w dokumencie, przez kogo i kiedy
  /// </summary>
  [DataContract]
  public partial class HistoryItem: Element
  {
    /// <summary>
    /// Wersja dokumentu. Może być złożona z wielu składowych i obejmować również wydanie.
    /// </summary>
    [XmlAttribute("Version")]
    [DefaultValue(null)]
    [DataMember]
    public string Version { get; set; }

    /// <summary>
    /// Opis wersji (opis zmian)
    /// </summary>
    [XmlElement("Description")]
    [DefaultValue(null)]
    [DataMember]
    public string Description { get; set; }

    /// <summary>
    /// Autor, który wprowadził zmiany
    /// </summary>
    [XmlAttribute("Author")]
    [DefaultValue(null)]
    [DataMember]
    public string Author { get; set; }

    /// <summary>
    /// Kiedy wersja/wydanie zostało otwarta
    /// </summary>
    [DataMember]
    public DateTime OpenedAt { get; set; }

    /// <summary>
    /// Kiedy wersja/wydanie zostało zamknięte
    /// </summary>
    [DataMember]
    public DateTime ClosedAt { get; set; }

    /// <summary>
    /// Czy data zamknięcia jest ustalona i ma być serializowana?
    /// </summary>
    public bool ShouldSerializeClosedAt() { return ClosedAt != new DateTime(); }

  }
}

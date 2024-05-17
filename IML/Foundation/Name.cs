using System.ComponentModel;
using System.Runtime.Serialization;

namespace Iml.Foundation
{
  /// <summary>
  /// Klasa reprezentująca nazwę elementu. 
  /// Element może mieć wiele nazw w różnych językach.
  /// W jednym języku może mieć główną nazwę oraz wiele aliasów.
  /// </summary>
  public partial class Name: Element
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public Name() { }

    /// <summary>
    /// Główny konstruktor.
    /// </summary>
    /// <param name="language">język, w którym wyrażona jest nazwa</param>
    /// <param name="value">wartośc nazwy</param>
    /// <param name="isAlias">czy nazwa jest aliasem</param>
    public Name(string language, string value, bool isAlias = false)
    {
      Language = language;
      Value = value;
      IsAlias = isAlias;
    }

    /// <summary>
    /// Identyfikator języka, w którym wyrażona jest dana nazwa.
    /// </summary>
    [DataMember]
    [DefaultValue(null)]
    public string Language { get; set; }

    /// <summary>
    /// Czy jest to alias?
    /// </summary>
    [DataMember]
    [DefaultValue(false)]
    public bool IsAlias { get; set; }

    /// <summary>
    /// Wartość nazwy
    /// </summary>
    [DataMember]
    [DefaultValue(null)]
    public string Value { get; set; }
  }
}

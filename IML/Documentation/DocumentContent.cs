using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation
{
  /// <summary>
  /// Abstrakcyjna klasa łacząca elementy inline i blokowe
  /// </summary>
  [KnownType(typeof(Inline))]
  [KnownType(typeof(Block))]
  public abstract class DocumentContent: Item
  {
    /// <summary>
    /// Konstruktor domyślny
    /// </summary>
    public DocumentContent () { }

    /// <summary>
    /// Konstruktor kopiujący
    /// </summary>
    /// <param name="owner"></param>
    public DocumentContent (Item owner) : base(owner) { }

    /// <summary>
    /// Ponieważ jest to klasa abstrakcyjna,
    /// więc musi udostępniać listę znanych typów konkretnych
    /// dla deserializacji. Typy te będą deklarowane w innych
    /// modułach, stąd lista typów jest budowana dynamicznie.
    /// </summary>
    public static List<Type> KnownTypes = new List<Type>();

    /// <summary>
    /// Czy element jest pusty
    /// </summary>
    /// <returns></returns>
    public abstract bool IsEmpty();

    /// <summary>
    /// Identyfikator rewizji utworzenia elementu
    /// </summary>
    [DefaultValue(null)]
    public string RevisionId { get; set; }

    /// <summary>
    /// Identyfikator rewizji właściwości
    /// </summary>
    [DefaultValue(null)]
    public string PropertiesRevisionId { get; set; }

    /// <summary>
    /// Identyfikator rewizji zawartości
    /// </summary>
    [DefaultValue(null)]
    public string ContentRevisionId { get; set; }

    /// <summary>
    /// Identyfikator rewizji wyglądu
    /// </summary>
    [DefaultValue(null)]
    public string LayoutRevisionId { get; set; }

    /// <summary>
    /// Identyfikator rewizji usunięcia elementu
    /// </summary>
    [DefaultValue(null)]
    public string DeleteRevisionId { get; set; }

  }
}

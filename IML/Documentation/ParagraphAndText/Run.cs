using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  /// <summary>
  /// Element składowy akapitu. Elementy tej klasy są ustawione jeden za drugim.
  /// </summary>
  public abstract partial class Run: Inline
  {
    ///// <summary>
    ///// Identyfikator rewizji utworzenia elementu
    ///// </summary>
    //[DefaultValue(null)]
    //public string RevisionId { get; set; }

    ///// <summary>
    ///// Identyfikator rewizji właściwości
    ///// </summary>
    //[DefaultValue(null)]
    //public string PropertiesRevisionId { get; set; }

    ///// <summary>
    ///// Identyfikator rewizji zawartości
    ///// </summary>
    //[DefaultValue(null)]
    //public string ContentRevisionId { get; set; }

    ///// <summary>
    ///// Identyfikator rewizji wyglądu
    ///// </summary>
    //[DefaultValue(null)]
    //public string LayoutRevisionId { get; set; }

    ///// <summary>
    ///// Identyfikator rewizji usunięcia elementu
    ///// </summary>
    //[DefaultValue(null)]
    //public string DeleteRevisionId { get; set; }

    /// <summary>
    /// format fragmentu
    /// </summary>
    [DefaultValue(null)]
    public TextFormat TextFormat { get; set; }

  }
}

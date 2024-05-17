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
  /// Klasa referencji do nagłówka/stopki
  /// </summary>
  [KnownType(typeof(HeaderReference))]
  [KnownType(typeof(FooterReference))]
  public abstract partial class HeaderFooterReference: Item
  {
    /// <summary>
    /// Typ nagłówka/stopki
    /// </summary>
    [DefaultValue(null)]
    public HeaderFooterType? Type { get; set; }

    /// <summary>
    /// Identyfikator relacji do nagłówka/stopki
    /// </summary>
    public override string Id { get; set; }
  }
}

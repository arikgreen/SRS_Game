using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Iml.Foundation;
using System.ComponentModel;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Styl graficzny
  /// </summary>
  public partial class GraphicStyle: Style
  {

    /// <summary>
    /// Typ stylu - czego dotyczy styl
    /// </summary>
    [OpenXMLAttributeName("type", "ST_StyleType", 1)]
    public override StyleType Type 
    {
      get { return StyleType.Graphics; }
    }

    /// <summary>
    /// Definicja sposobu rysowania linii
    /// </summary>
    [DefaultValue(null)]
    public Stroke Stroke { get; set; }

    /// <summary>
    /// Definicja sposobu wypełnienia
    /// </summary>
    [DefaultValue(null)]
    public Fill Fill { get; set; }

    /// <summary>
    /// Definicja sposobu wypełnienia tła
    /// </summary>
    [DefaultValue(null)]
    public Fill Background { get; set; }

    /// <summary>
    /// Definicja efektów graficznych
    /// </summary>
    [DefaultValue(null)]
    public Effects Effects { get; set; } 
  }
}

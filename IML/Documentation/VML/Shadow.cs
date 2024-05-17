using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Cień w dokumencie VML
  /// </summary>
  public partial class Shadow: VmlItem
  {
    // Summary:
    //      Shadow Primary Color.
    //     Represents the following attribute in the schema: color
    //[SchemaAttr(0, "color")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string Color { get; set; }
    //
    // Summary:
    //      Shadow Secondary Color.
    //     Represents the following attribute in the schema: color2
    //[SchemaAttr(0, "color2")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string Color2 { get; set; }

    //
    // Summary:
    //      Shadow Perspective Matrix.
    //     Represents the following attribute in the schema: matrix
    //[SchemaAttr(0, "matrix")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string Matrix { get; set; }
    //
    // Summary:
    //      Shadow Transparency.
    //     Represents the following attribute in the schema: obscured
    //[SchemaAttr(0, "obscured")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public bool? Obscured { get; set; }
    //
    // Summary:
    //      Shadow Primary Offset.
    //     Represents the following attribute in the schema: offset
    //[SchemaAttr(0, "offset")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string Offset { get; set; }
    //
    // Summary:
    //      Shadow Secondary Offset.
    //     Represents the following attribute in the schema: offset2
    //[SchemaAttr(0, "offset2")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string Offset2 { get; set; }
    //
    // Summary:
    //      Shadow Toggle.
    //     Represents the following attribute in the schema: on
    //[SchemaAttr(0, "on")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public bool? On { get; set; }
    //
    // Summary:
    //      Shadow Opacity.
    //     Represents the following attribute in the schema: opacity
    //[SchemaAttr(0, "opacity")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string Opacity { get; set; }
    //
    // Summary:
    //      Shadow Origin.
    //     Represents the following attribute in the schema: origin
    //[SchemaAttr(0, "origin")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string Origin { get; set; }
    //
    // Summary:
    //      Shadow Type.
    //     Represents the following attribute in the schema: type
    //[SchemaAttr(0, "type")]
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    public string /*EnumValue<ShadowValues>*/ Type { get; set; }
  }
}

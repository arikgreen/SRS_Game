using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Iml.Foundation;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Uchwyt kształtu
  /// </summary>
  public partial class ShapeHandle: Item
  {
    // Summary:
    //      Invert Handle's X Position.
    //     Represents the following attribute in the schema: invx
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "invx")]
    [DefaultValue(null)]
    public bool? InvertX { get; set; }
    //
    // Summary:
    //      Invert Handle's Y Position.
    //     Represents the following attribute in the schema: invy
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "invy")]
    [DefaultValue(null)]
    public bool? InvertY { get; set; }
    //
    // Summary:
    //      Handle Coordinate Mapping.
    //     Represents the following attribute in the schema: map
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "map")]
    [DefaultValue(null)]
    public string Map { get; set; }
    //
    // Summary:
    //      Handle Polar Center.
    //     Represents the following attribute in the schema: polar
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "polar")]
    [DefaultValue(null)]
    public string Polar { get; set; }
    //
    // Summary:
    //      Handle Position.
    //     Represents the following attribute in the schema: position
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "position")]
    [DefaultValue(null)]
    public string Position { get; set; }
    //
    // Summary:
    //      Handle Polar Radius Range.
    //     Represents the following attribute in the schema: radiusrange
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "radiusrange")]
    [DefaultValue(null)]
    public string RadiusRange { get; set; }
    //
    // Summary:
    //      Handle Inversion Toggle.
    //     Represents the following attribute in the schema: switch
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "switch")]
    [DefaultValue(null)]
    public bool? Switch { get; set; }
    //
    // Summary:
    //      Handle X Position Range.
    //     Represents the following attribute in the schema: xrange
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "xrange")]
    [DefaultValue(null)]
    public string XRange { get; set; }
    //
    // Summary:
    //      Handle Y Position Range.
    //     Represents the following attribute in the schema: yrange
    /// <summary>
    /// ???
    /// </summary>
    //[SchemaAttr(0, "yrange")]
    [DefaultValue(null)]
    public string YRange { get; set; }
  }
}

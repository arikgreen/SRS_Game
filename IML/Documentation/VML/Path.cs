using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Ścieżka rysowania
  /// </summary>
  public partial class Path: VmlItem
  {
    // Summary:
    //      Extrusion Toggle.
    //     Represents the following attribute in the schema: o:extrusionok
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "extrusionok")]
    public bool? AllowExtrusion { get; set; }
    //
    // Summary:
    //      Shape Fill Toggle.
    //     Represents the following attribute in the schema: fillok
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "fillok")]
    public bool? AllowFill { get; set; }
    //
    // Summary:
    //      Gradient Shape Toggle.
    //     Represents the following attribute in the schema: gradientshapeok
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "gradientshapeok")]
    public bool? AllowGradientShape { get; set; }
    //
    // Summary:
    //      Inset Stroke From Path Flag.
    //     Represents the following attribute in the schema: insetpenok
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "insetpenok")]
    public bool? AllowInsetPen { get; set; }
    //
    // Summary:
    //      Shadow Toggle.
    //     Represents the following attribute in the schema: shadowok
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "shadowok")]
    public bool? AllowShading { get; set; }
    //
    // Summary:
    //      Stroke Toggle.
    //     Represents the following attribute in the schema: strokeok
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "strokeok")]
    public bool? AllowStroke { get; set; }
    //
    // Summary:
    //      Text Path Toggle.
    //     Represents the following attribute in the schema: textpathok
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "textpathok")]
    public bool? AllowTextPath { get; set; }
    //
    // Summary:
    //      Connection Point Connect Angles.
    //     Represents the following attribute in the schema: o:connectangles
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "connectangles")]
    public string ConnectAngles { get; set; }
    //
    // Summary:
    //      Connection Points.
    //     Represents the following attribute in the schema: o:connectlocs
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "connectlocs")]
    public string ConnectionPoints { get; set; }
    //
    // Summary:
    //      Connection Point Type.
    //     Represents the following attribute in the schema: o:connecttype
    /// <summary>
    /// 
    /// </summary>
    //[SchemaAttr(27, "connecttype")]
    //[TypeConverter("Iml.Documentation.EnumValueTypeConverter")]
    public ConnectionPointType? ConnectionPointType { get; set; }
    //
    // Summary:
    //      Limo Stretch Point.
    //     Represents the following attribute in the schema: limo
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "limo")]
    public string Limo { get; set; }
    //
    // Summary:
    //      Arrowhead Display Toggle.
    //     Represents the following attribute in the schema: arrowok
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "arrowok")]
    public bool? ShowArrowhead { get; set; }
    //
    // Summary:
    //      Text Box Bounding Box.
    //     Represents the following attribute in the schema: textboxrect
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "textboxrect")]
    public string TextboxRectangle { get; set; }
    //
    // Summary:
    //      Path Definition.
    //     Represents the following attribute in the schema: v
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "v")]
    public string Value { get; set; }

  }
}

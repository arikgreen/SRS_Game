using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Wypełnienie VML
  /// </summary>
  public partial class Fill: VmlItem
  {
    // Summary:
    //      Align Image With Shape.
    //     Represents the following attribute in the schema: alignshape
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "alignshape")]
    public bool? AlignShape { get; set; }
    //
    // Summary:
    //      Alternate Image Reference Location.
    //     Represents the following attribute in the schema: o:althref
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "althref")]
    public string AlternateImageReference { get; set; }
    //
    // Summary:
    //      Gradient Angle.
    //     Represents the following attribute in the schema: angle
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "angle")]
    public string /*double?*/ Angle { get; set; }
    //
    // Summary:
    //      Image Aspect Ratio.
    //     Represents the following attribute in the schema: aspect
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "aspect")]
    public string /*ImageAspectType?*/ Aspect { get; set; }
    //
    // Summary:
    //      Primary Color.
    //     Represents the following attribute in the schema: color
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "color")]
    public string Color { get; set; }
    //
    // Summary:
    //      Secondary Color.
    //     Represents the following attribute in the schema: color2
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "color2")]
    public string Color2 { get; set; }
    //
    // Summary:
    //      Intermediate Colors.
    //     Represents the following attribute in the schema: colors
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "colors")]
    public string Colors { get; set; }
    //
    // Summary:
    //      Detect Mouse Click.
    //     Represents the following attribute in the schema: o:detectmouseclick
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "detectmouseclick")]
    public bool? DetectMouseClick { get; set; }
    ////
    //// Summary:
    ////   FillExtendedProperties.
    ////  Represents the following element tag in the schema: o:fill
    //public FillExtendedProperties FillExtendedProperties { get; set; }
    //
    // Summary:
    //      Gradient Center.
    //     Represents the following attribute in the schema: focus
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "focus")]
    public string Focus { get; set; }
    //
    // Summary:
    //      Radial Gradient Center.
    //     Represents the following attribute in the schema: focusposition
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "focusposition")]
    public string FocusPosition { get; set; }
    //
    // Summary:
    //      Radial Gradient Size.
    //     Represents the following attribute in the schema: focussize
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "focussize")]
    public string FocusSize { get; set; }
    //
    // Summary:
    //      Hyperlink Target.
    //     Represents the following attribute in the schema: o:href
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "href")]
    public string Href { get; set; }
    //
    // Summary:
    //      Gradient Fill Method.
    //     Represents the following attribute in the schema: method
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "method")]
    public string /*EnumValue<FillMethodValues>*/ Method { get; set; }
    //
    // Summary:
    //      Fill Toggle.
    //     Represents the following attribute in the schema: on
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "on")]
    public bool? On { get; set; }
    //
    // Summary:
    //      Primary Color Opacity.
    //     Represents the following attribute in the schema: opacity
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "opacity")]
    public string Opacity { get; set; }
    //
    // Summary:
    //      Secondary Color Opacity.
    //     Represents the following attribute in the schema: o:opacity2
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "opacity2")]
    public string Opacity2 { get; set; }
    //
    // Summary:
    //      Fill Image Origin.
    //     Represents the following attribute in the schema: origin
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "origin")]
    public string Origin { get; set; }
    //
    // Summary:
    //      Fill Image Position.
    //     Represents the following attribute in the schema: position
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "position")]
    public string Position { get; set; }
    //
    // Summary:
    //      Recolor Fill as Picture.
    //     Represents the following attribute in the schema: recolor
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "recolor")]
    public bool? Recolor { get; set; }
    //
    // Summary:
    //      Relationship to Part.
    //     Represents the following attribute in the schema: r:id
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(19, "id")]
    public string RelationshipId { get; set; }
    //
    // Summary:
    //      Relationship to Part.
    //     Represents the following attribute in the schema: o:relid
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "relid")]
    public string PartId { get; set; }
    // Summary:
    //      Rotate Fill with Shape.
    //     Represents the following attribute in the schema: rotate
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "rotate")]
    public bool? Rotate { get; set; }
    //
    // Summary:
    //      Fill Image Size.
    //     Represents the following attribute in the schema: size
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "size")]
    public string Size { get; set; }
    //
    // Summary:
    //      Fill Image Source.
    //     Represents the following attribute in the schema: src
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "src")]
    public string Source { get; set; }
    //
    // Summary:
    //      Title.
    //     Represents the following attribute in the schema: o:title
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(27, "title")]
    public string Title { get; set; }
    //
    // Summary:
    //      Fill Type.
    //     Represents the following attribute in the schema: type
    /// <summary>
    /// ???
    /// </summary>
    [DefaultValue(null)]
    //[SchemaAttr(0, "type")]
    public string /*EnumValue<FillTypeValues>*/ Type { get; set; }


  }
}

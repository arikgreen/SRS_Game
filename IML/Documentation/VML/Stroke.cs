using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation.VML
{
  /// <summary>
  /// Element opisujący rysowaną linię w VML'u
  /// </summary>
  public partial class Stroke: VmlItem
  {
    //adj (Adjustment Parameters)
    /// <summary>
    /// Parametry dopasowujące kształt
    /// </summary>
    [DefaultValue(null)]
    public string Adjustment { get; set; }

    //dashstyle (Stroke Dash Pattern)
    /// <summary>
    /// Styl linii przerywanej
    /// </summary>
    [DefaultValue(null)]
    public string DashStyle { get; set; }

    //endarrow (Line End Arrowhead)
    /// <summary>
    /// Rodzaj zakończenia
    /// </summary>
    [DefaultValue(null)]
    public string EndArrow { get; set; }

    //endarrowlength (Line End Arrowhead Length)
    /// <summary>
    /// Długość zakończenia
    /// </summary>
    [DefaultValue(null)]
    public string EndArrowLength { get; set; }

    //endarrowwidth (Line End Arrowhead Width)
    /// <summary>
    /// Szerokość zakończenia
    /// </summary>
    [DefaultValue(null)]
    public string EndArrowWidth { get; set; }
    
    //endcap (Line End Cap)
    /// <summary>
    /// Sposób kończenia linii
    /// </summary>
    [DefaultValue(null)]
    public string EndCap { get; set; }

    //filltype (Stroke Image Style)
    /// <summary>
    /// Sposób wypełnienia linii
    /// </summary>
    [DefaultValue(null)]
    public string FillType { get; set; }

    //forcedash (Force Dashed Outline)
    /// <summary>
    /// Wymuszanie obwiedni przerywanej
    /// </summary>
    [DefaultValue(null)]
    public bool? ForceDash { get; set; }

    //imagealignshape (Stoke Image Alignment)
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    public string ImageAlignShape { get; set; }

    //imageaspect (Stroke Image Aspect Ratio)
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    public string ImageAspect { get; set; }

    //imagesize (Stroke Image Size)
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    public string ImageSize { get; set; }

    //insetpen (Inset Border From Path)
    /// <summary>
    /// Czy obrys jest wewnątrz kształtu
    /// </summary>
    [DefaultValue(null)]
    public bool? InsetPen { get; set; }

    //imagesize (Stroke Image Size)
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    public string JoinStyle { get; set; }

    //linestyle (Stroke Line Style)
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    public string LineStyle { get; set; }

    //miterlimit (Miter Joint Limit)
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    public string MiterLimit { get; set; }

    //on (Stroke Toggle)
    /// <summary>
    /// 
    /// </summary>
    [DefaultValue(null)]
    public Boolean? On { get; set; }

    //relid (Relationship to Part)
    /// <summary>
    /// Relacja do części
    /// </summary>
    [DefaultValue(null)]
    public string PartId { get; set; }
    
    //id (Relationship)
    /// <summary>
    /// Relacja
    /// </summary>
    [DefaultValue(null)]
    public string Relationship { get; set; }

    //src (Stroke Image Location)
    /// <summary>
    /// Relacja
    /// </summary>
    [DefaultValue(null)]
    public string Src { get; set; }

    //startarrow (Line Start Arrowhead)
    /// <summary>
    /// Rodzaj zakończenia
    /// </summary>
    [DefaultValue(null)]
    public string StartArrow { get; set; }
    
    //startarrowlength (Line Start Arrowhead Length)
    /// <summary>
    /// Długość zakończenia
    /// </summary>
    [DefaultValue(null)]
    public string StartArrowLength { get; set; }
    
    //startarrowwidth (Line Start Arrowhead Width)
    /// <summary>
    /// Szerokość zakończenia
    /// </summary>
    [DefaultValue(null)]
    public string StartArrowWidth { get; set; }
    
    //weight (Stroke Weight)
    /// <summary>
    /// Grubość linii
    /// </summary>
    [DefaultValue(null)]
    public string Weight { get; set; }
  }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Iml.Documentation
{
  public partial class ParagraphFormat
  {
    /// <summary>
    /// Czy właściwości są puste?
    /// </summary>
    public new bool IsEmpty ()
    {
      return this.Alignment == null
        && !this.ShouldSerializeBorders()
        && this.DivId == null
        && this.EndIndent == null
        && this.FirstLineIndent == null
        && this.HangingIndent == null
        && this.Interline == null
        && this.KeepLinesTogether == null
        && this.KeepWithNext == null
        && this.LeftIndent == null
        && this.Numbering == null
        && this.OutlineLevel == null
        && this.RevisionId == null
        && this.RightIndent == null
        && this.SpacingAfter == null
        && this.SpacingBefore == null
        && this.StartIndent == null
        && this.StyleId == null
        && !ShouldSerializeTabStops()
        && this.WidowControl == null
      && base.IsEmpty();
    }

    /// <summary>
    /// Połączenie dwóch zbiorów właściwości. Właściwości pierwszego zbioru mają pierwszeństwo.
    /// </summary>
    public static ParagraphFormat operator | (ParagraphFormat A, ParagraphFormat B)
    {
      if (B == null)
        return A;
      if (A == null)
        return B;
      ParagraphFormat result = new ParagraphFormat();
      result.Alignment = A.Alignment ?? B.Alignment;
      result.Interline = A.Interline ?? B.Interline;
      result.SpacingBefore = A.SpacingBefore ?? B.SpacingBefore;
      result.SpacingAfter = A.SpacingAfter ?? B.SpacingAfter;
      return result;
    }

    //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    //public HorizontalAlignment HAlignment
    //{
    //  get
    //  {
    //    return (this.Alignment != null) ? (HorizontalAlignment)(this.Alignment) : HorizontalAlignment.Left;
    //  }
    //  set
    //  {
    //    this.Alignment = value;
    //  }
    //}  

  }
}

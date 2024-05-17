using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("textParagraphProperties")]
  [Alias("TextParagraphProperties")]
  public class TextParagraphPropertiesType
  {
    [Tag("textMargin")]
    TextMarginValue MarL{ get; set; }

    [Tag("textMargin")]
    TextMarginValue MarR{ get; set; }

    [Tag("textIndentLevelType")]
    TextIndentLevelTypeValue Lvl{ get; set; }

    [Tag("textIndent")]
    TextIndentValue Indent{ get; set; }

    [Tag("textAlignType")]
    TextAlignmentTypeValues Algn{ get; set; }

    [Tag("coordinate32")]
    Coordinate32Value DefTabSz{ get; set; }

    [Tag("boolean")]
    Boolean Rtl{ get; set; }

    [Tag("boolean")]
    Boolean EaLnBrk{ get; set; }

    [Tag("textFontAlignType")]
    TextFontAlignmentValues FontAlgn{ get; set; }

    [Tag("boolean")]
    Boolean LatinLnBrk{ get; set; }

    [Tag("boolean")]
    Boolean HangingPunct{ get; set; }

  }
}

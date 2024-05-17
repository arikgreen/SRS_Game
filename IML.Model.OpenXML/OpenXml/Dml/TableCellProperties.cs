using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("tableCellProperties")]
  [Alias("TableCellProperties")]
  public class TableCellProperties
  {
    [Tag("coordinate32")]
    Coordinate32Value MarL{ get; set; }

    [Tag("coordinate32")]
    Coordinate32Value MarR{ get; set; }

    [Tag("coordinate32")]
    Coordinate32Value MarT{ get; set; }

    [Tag("coordinate32")]
    Coordinate32Value MarB{ get; set; }

    [Tag("textVerticalType")]
    TextVerticalValues Vert{ get; set; }

    [Tag("textAnchoringType")]
    TextAnchoringTypeValues Anchor{ get; set; }

    [Tag("boolean")]
    Boolean AnchorCtr{ get; set; }

    [Tag("textHorzOverflowType")]
    TextHorizontalOverflowValues HorzOverflow{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("tblPPr")]
  [Alias("TblPPr")]
  public class TablePositionProperties
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue LeftFromText{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue RightFromText{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue TopFromText{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue BottomFromText{ get; set; }

    [Tag("vAnchor")]
    VerticalAnchorValues VertAnchor{ get; set; }

    [Tag("hAnchor")]
    HorizontalAnchorValues HorzAnchor{ get; set; }

    [Tag("xAlign")]
    FileFormatVersions TblpXSpec{ get; set; }

    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue TblpX{ get; set; }

    [Tag("yAlign")]
    FileFormatVersions TblpYSpec{ get; set; }

    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue TblpY{ get; set; }

  }
}

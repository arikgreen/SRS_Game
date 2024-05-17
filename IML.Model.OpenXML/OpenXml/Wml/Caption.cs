using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("caption")]
  [Alias("Caption")]
  public class Caption
  {
    [Tag("string")]
    String Name{ get; set; }

    [Tag("captionPos")]
    CaptionPositionValues Pos{ get; set; }

    [Tag("onOff")]
    OnOffValue ChapNum{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Heading{ get; set; }

    [Tag("onOff")]
    OnOffValue NoLabel{ get; set; }

    [Tag("numberFormat")]
    NumberFormatValues NumFmt{ get; set; }

    [Tag("chapterSep")]
    ChapterSeparatorValues Sep{ get; set; }

  }
}

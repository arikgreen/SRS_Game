using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("pageNumber")]
  [Alias("PageNumber")]
  public class PageNumber
  {
    [Tag("numberFormat")]
    NumberFormatValues Fmt{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Start{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue ChapStyle{ get; set; }

    [Tag("chapterSep")]
    ChapterSeparatorValues ChapSep{ get; set; }

  }
}

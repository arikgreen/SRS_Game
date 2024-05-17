using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("pageSz")]
  [Alias("PageSz")]
  public class PageSize
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue W{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue H{ get; set; }

    [Tag("pageOrientation")]
    PageOrientationValues Orient{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Code{ get; set; }

  }
}

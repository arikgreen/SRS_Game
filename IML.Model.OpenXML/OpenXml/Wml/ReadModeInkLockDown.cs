using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("readingModeInkLockDown")]
  [Alias("ReadingModeInkLockDown")]
  public class ReadModeInkLockDown
  {
    [Tag("onOff")]
    OnOffValue ActualPg{ get; set; }

    [Tag("pixelsMeasure")]
    PixelsMeasureValue W{ get; set; }

    [Tag("pixelsMeasure")]
    PixelsMeasureValue H{ get; set; }

    [Tag("decimalNumberOrPercent")]
    DecimalNumberOrPercentValue FontSz{ get; set; }

  }
}

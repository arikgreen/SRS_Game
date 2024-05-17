using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("lineNumber")]
  [Alias("LineNumber")]
  public class LineNumberType
  {
    [Tag("decimalNumber")]
    DecimalNumberValue CountBy{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Start{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Distance{ get; set; }

    [Tag("lineNumberRestart")]
    LineNumberRestartValues Restart{ get; set; }

  }
}

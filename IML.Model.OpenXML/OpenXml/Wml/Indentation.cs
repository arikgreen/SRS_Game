using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("ind")]
  [Alias("Ind")]
  public class Indentation
  {
    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue Start{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue StartChars{ get; set; }

    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue End{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue EndChars{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Hanging{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue HangingChars{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue FirstLine{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue FirstLineChars{ get; set; }

  }
}

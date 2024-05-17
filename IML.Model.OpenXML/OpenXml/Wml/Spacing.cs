using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("spacing")]
  [Alias("Spacing")]
  public class Spacing
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue Before{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue BeforeLines{ get; set; }

    [Tag("onOff")]
    OnOffValue BeforeAutospacing{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue After{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue AfterLines{ get; set; }

    [Tag("onOff")]
    OnOffValue AfterAutospacing{ get; set; }

    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue Line{ get; set; }

    [Tag("lineSpacingRule")]
    LineSpacingRuleValues LineRule{ get; set; }

  }
}

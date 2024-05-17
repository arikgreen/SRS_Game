using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("pageMar")]
  [Alias("PageMar")]
  public class PageMargin
  {
    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue Top{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Right{ get; set; }

    [Tag("signedTwipsMeasure")]
    SignedTwipsMeasureValue Bottom{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Left{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Header{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Footer{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Gutter{ get; set; }

  }
}

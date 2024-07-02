using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("columns")]
  [Alias("Columns")]
  public class Columns
  {
    [Tag("onOff")]
    OnOffValue EqualWidth{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Space{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Num{ get; set; }

    [Tag("onOff")]
    OnOffValue Sep{ get; set; }

  }
}

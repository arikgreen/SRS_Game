using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("ftnEdnRef")]
  [Alias("FtnEdnRef")]
  public class FootnoteReferenceMark
  {
    [Tag("onOff")]
    OnOffValue CustomMarkFollows{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Id{ get; set; }

  }
}

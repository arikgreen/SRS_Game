using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("ftnEdn")]
  [Alias("FtnEdn")]
  public class BasedOn
  {
    [Tag("ftnEdn")]
    FootnoteEndnoteValues Type{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Id{ get; set; }

  }
}

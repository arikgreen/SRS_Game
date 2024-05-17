using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("latentStyles")]
  [Alias("LatentStyles")]
  public class LatentStyles
  {
    [Tag("onOff")]
    OnOffValue DefLockedState{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue DefUIPriority{ get; set; }

    [Tag("onOff")]
    OnOffValue DefSemiHidden{ get; set; }

    [Tag("onOff")]
    OnOffValue DefUnhideWhenUsed{ get; set; }

    [Tag("onOff")]
    OnOffValue DefQFormat{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue Count{ get; set; }

  }
}

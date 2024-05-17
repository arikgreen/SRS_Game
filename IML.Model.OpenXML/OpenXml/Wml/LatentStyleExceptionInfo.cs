using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("lsdException")]
  [Alias("LsdException")]
  public class LatentStyleExceptionInfo
  {
    [Tag("string")]
    String Name{ get; set; }

    [Tag("onOff")]
    OnOffValue Locked{ get; set; }

    [Tag("decimalNumber")]
    DecimalNumberValue UiPriority{ get; set; }

    [Tag("onOff")]
    OnOffValue SemiHidden{ get; set; }

    [Tag("onOff")]
    OnOffValue UnhideWhenUsed{ get; set; }

    [Tag("onOff")]
    OnOffValue QFormat{ get; set; }

  }
}

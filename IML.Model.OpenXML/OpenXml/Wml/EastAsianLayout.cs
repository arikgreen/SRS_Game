using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("eastAsianLayout")]
  [Alias("EastAsianLayout")]
  public class EastAsianLayout
  {
    [Tag("decimalNumber")]
    DecimalNumberValue Id{ get; set; }

    [Tag("onOff")]
    OnOffValue Combine{ get; set; }

    [Tag("combineBrackets")]
    CombineBracketValues CombineBrackets{ get; set; }

    [Tag("onOff")]
    OnOffValue Vert{ get; set; }

    [Tag("onOff")]
    OnOffValue VertCompress{ get; set; }

  }
}

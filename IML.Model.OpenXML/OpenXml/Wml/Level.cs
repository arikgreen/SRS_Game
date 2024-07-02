using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("lvl")]
  [Alias("Lvl")]
  public class Level
  {
    [Tag("decimalNumber")]
    DecimalNumberValue Ilvl{ get; set; }

    [Tag("longHexNumber")]
    LongHexNumberValue Tplc{ get; set; }

    [Tag("onOff")]
    OnOffValue Tentative{ get; set; }

  }
}

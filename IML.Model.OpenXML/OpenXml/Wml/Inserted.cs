using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("cnf")]
  [Alias("Cnf")]
  public class Inserted
  {
    [Tag("onOff")]
    OnOffValue FirstRow{ get; set; }

    [Tag("onOff")]
    OnOffValue LastRow{ get; set; }

    [Tag("onOff")]
    OnOffValue FirstColumn{ get; set; }

    [Tag("onOff")]
    OnOffValue LastColumn{ get; set; }

    [Tag("onOff")]
    OnOffValue OddVBand{ get; set; }

    [Tag("onOff")]
    OnOffValue EvenVBand{ get; set; }

    [Tag("onOff")]
    OnOffValue OddHBand{ get; set; }

    [Tag("onOff")]
    OnOffValue EvenHBand{ get; set; }

    [Tag("onOff")]
    OnOffValue FirstRowFirstColumn{ get; set; }

    [Tag("onOff")]
    OnOffValue FirstRowLastColumn{ get; set; }

    [Tag("onOff")]
    OnOffValue LastRowFirstColumn{ get; set; }

    [Tag("onOff")]
    OnOffValue LastRowLastColumn{ get; set; }

  }
}

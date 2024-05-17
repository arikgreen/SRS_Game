using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("tblLook")]
  [Alias("TblLook")]
  public class TableLook
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
    OnOffValue NoHBand{ get; set; }

    [Tag("onOff")]
    OnOffValue NoVBand{ get; set; }

  }
}

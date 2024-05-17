using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("fldChar")]
  [Alias("FldChar")]
  public class FieldChar
  {
    [Tag("fldCharType")]
    FieldCharValues FldCharType{ get; set; }

    [Tag("onOff")]
    OnOffValue FldLock{ get; set; }

    [Tag("onOff")]
    OnOffValue Dirty{ get; set; }

  }
}

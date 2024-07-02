using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("simpleField")]
  [Alias("SimpleField")]
  public class SimpleField
  {
    [Tag("string")]
    String Instr{ get; set; }

    [Tag("onOff")]
    OnOffValue FldLock{ get; set; }

    [Tag("onOff")]
    OnOffValue Dirty{ get; set; }

  }
}

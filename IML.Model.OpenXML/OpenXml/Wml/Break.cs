using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("br")]
  [Alias("Br")]
  public class Break
  {
    [Tag("brType")]
    BreakValues Type{ get; set; }

    [Tag("brClear")]
    BreakTextRestartLocationValues Clear{ get; set; }

  }
}

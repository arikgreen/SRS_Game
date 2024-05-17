using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("tickMark")]
  [Alias("TickMark")]
  public class TickMarkType
  {
    [Tag("tickMark")]
    TickMarkValues Val{ get; set; }

  }
}

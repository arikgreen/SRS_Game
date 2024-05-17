using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("tickLblPos")]
  [Alias("TickLblPos")]
  public class TickLabelPosition
  {
    [Tag("tickLblPos")]
    TickLabelPositionValues Val{ get; set; }

  }
}

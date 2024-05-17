using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("legendPos")]
  [Alias("LegendPos")]
  public class LegendPosition
  {
    [Tag("legendPos")]
    LegendPositionValues Val{ get; set; }

  }
}

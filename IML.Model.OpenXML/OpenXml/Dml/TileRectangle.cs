using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("relativeRect")]
  [Alias("RelativeRect")]
  public class TileRectangle
  {
    [Tag("percentage")]
    PercentageValue L{ get; set; }

    [Tag("percentage")]
    PercentageValue T{ get; set; }

    [Tag("percentage")]
    PercentageValue R{ get; set; }

    [Tag("percentage")]
    PercentageValue B{ get; set; }

  }
}

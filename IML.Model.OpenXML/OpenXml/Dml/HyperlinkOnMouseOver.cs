using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("relativeOffsetEffect")]
  [Alias("RelativeOffsetEffect")]
  public class HyperlinkOnMouseOver
  {
    [Tag("percentage")]
    PercentageValue Tx{ get; set; }

    [Tag("percentage")]
    PercentageValue Ty{ get; set; }

  }
}

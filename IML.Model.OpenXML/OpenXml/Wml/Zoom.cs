using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("zoom")]
  [Alias("Zoom")]
  public class Zoom
  {
    [Tag("zoom")]
    PresetZoomValues Val{ get; set; }

    [Tag("decimalNumberOrPercent")]
    DecimalNumberOrPercentValue Percent{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("luminanceEffect")]
  [Alias("LuminanceEffect")]
  public class LuminanceEffect
  {
    [Tag("fixedPercentage")]
    FixedPercentageValue Bright{ get; set; }

    [Tag("fixedPercentage")]
    FixedPercentageValue Contrast{ get; set; }

  }
}

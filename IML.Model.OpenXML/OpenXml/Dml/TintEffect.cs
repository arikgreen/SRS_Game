using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("tintEffect")]
  [Alias("TintEffect")]
  public class TintEffect
  {
    [Tag("positiveFixedAngle")]
    PositiveFixedAngleValue Hue{ get; set; }

    [Tag("fixedPercentage")]
    FixedPercentageValue Amt{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("innerShadowEffect")]
  [Alias("InnerShadowEffect")]
  public class InnerShadow
  {
    [Tag("positiveCoordinate")]
    PositiveCoordinateValue BlurRad{ get; set; }

    [Tag("positiveCoordinate")]
    PositiveCoordinateValue Dist{ get; set; }

    [Tag("positiveFixedAngle")]
    PositiveFixedAngleValue Dir{ get; set; }

  }
}

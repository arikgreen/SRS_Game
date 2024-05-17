using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("outerShadowEffect")]
  [Alias("OuterShadowEffect")]
  public class OuterShadow
  {
    [Tag("positiveCoordinate")]
    PositiveCoordinateValue BlurRad{ get; set; }

    [Tag("positiveCoordinate")]
    PositiveCoordinateValue Dist{ get; set; }

    [Tag("positiveFixedAngle")]
    PositiveFixedAngleValue Dir{ get; set; }

    [Tag("percentage")]
    PercentageValue Sx{ get; set; }

    [Tag("percentage")]
    PercentageValue Sy{ get; set; }

    [Tag("fixedAngle")]
    FixedAngleValue Kx{ get; set; }

    [Tag("fixedAngle")]
    FixedAngleValue Ky{ get; set; }

    [Tag("rectAlignment")]
    RectangleAlignmentValues Algn{ get; set; }

    [Tag("boolean")]
    Boolean RotWithShape{ get; set; }

  }
}

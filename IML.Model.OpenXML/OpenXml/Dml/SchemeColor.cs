using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("sphereCoords")]
  [Alias("SphereCoords")]
  public class SchemeColor
  {
    [Tag("positiveFixedAngle")]
    PositiveFixedAngleValue Lat{ get; set; }

    [Tag("positiveFixedAngle")]
    PositiveFixedAngleValue Lon{ get; set; }

    [Tag("positiveFixedAngle")]
    PositiveFixedAngleValue Rev{ get; set; }

  }
}

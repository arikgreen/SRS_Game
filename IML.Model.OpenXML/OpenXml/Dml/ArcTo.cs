using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("path2DArcTo")]
  [Alias("Path2DArcTo")]
  public class ArcTo
  {
    [Tag("adjCoordinate")]
    AdjCoordinateValue WR{ get; set; }

    [Tag("adjCoordinate")]
    AdjCoordinateValue HR{ get; set; }

    [Tag("adjAngle")]
    AdjAngleValue StAng{ get; set; }

    [Tag("adjAngle")]
    AdjAngleValue SwAng{ get; set; }

  }
}

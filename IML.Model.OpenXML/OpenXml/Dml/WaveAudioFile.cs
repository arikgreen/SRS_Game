using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("polarAdjustHandle")]
  [Alias("PolarAdjustHandle")]
  public class WaveAudioFile
  {
    [Tag("geomGuideName")]
    GeomGuideNameValue GdRefR{ get; set; }

    [Tag("adjCoordinate")]
    AdjCoordinateValue MinR{ get; set; }

    [Tag("adjCoordinate")]
    AdjCoordinateValue MaxR{ get; set; }

    [Tag("geomGuideName")]
    GeomGuideNameValue GdRefAng{ get; set; }

    [Tag("adjAngle")]
    AdjAngleValue MinAng{ get; set; }

    [Tag("adjAngle")]
    AdjAngleValue MaxAng{ get; set; }

  }
}

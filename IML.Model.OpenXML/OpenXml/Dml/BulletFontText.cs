using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("adjPoint2D")]
  [Alias("AdjPoint2D")]
  public class BulletFontText
  {
    [Tag("adjCoordinate")]
    AdjCoordinateValue X{ get; set; }

    [Tag("adjCoordinate")]
    AdjCoordinateValue Y{ get; set; }

  }
}

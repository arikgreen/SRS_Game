using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("geomRect")]
  [Alias("GeomRect")]
  public class UseShapeRectangle
  {
    [Tag("adjCoordinate")]
    AdjCoordinateValue L{ get; set; }

    [Tag("adjCoordinate")]
    AdjCoordinateValue T{ get; set; }

    [Tag("adjCoordinate")]
    AdjCoordinateValue R{ get; set; }

    [Tag("adjCoordinate")]
    AdjCoordinateValue B{ get; set; }

  }
}

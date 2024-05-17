using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("path2D")]
  [Alias("Path2D")]
  public class PathGradientFill
  {
    [Tag("positiveCoordinate")]
    PositiveCoordinateValue W{ get; set; }

    [Tag("positiveCoordinate")]
    PositiveCoordinateValue H{ get; set; }

    [Tag("pathFillMode")]
    PathFillModeValues Fill{ get; set; }

    [Tag("boolean")]
    Boolean Stroke{ get; set; }

    [Tag("boolean")]
    Boolean ExtrusionOk{ get; set; }

  }
}

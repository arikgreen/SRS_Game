using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("positiveSize2D")]
  [Alias("PositiveSize2D")]
  public class PositiveSize2DType
  {
    [Tag("positiveCoordinate")]
    PositiveCoordinateValue Cx{ get; set; }

    [Tag("positiveCoordinate")]
    PositiveCoordinateValue Cy{ get; set; }

  }
}

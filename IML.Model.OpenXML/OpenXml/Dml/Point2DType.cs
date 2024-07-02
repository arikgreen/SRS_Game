using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("point2D")]
  [Alias("Point2D")]
  public class Point2DType
  {
    [Tag("coordinate")]
    CoordinateValue X{ get; set; }

    [Tag("coordinate")]
    CoordinateValue Y{ get; set; }

  }
}

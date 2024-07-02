using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("shp")]
  [Alias("Shp")]
  public class Shape
  {
    [Tag("shp")]
    ShapeDelimiterValues Val{ get; set; }

  }
}

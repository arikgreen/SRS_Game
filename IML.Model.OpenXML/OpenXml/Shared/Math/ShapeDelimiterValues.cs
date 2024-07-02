using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("Shp")]
  public enum ShapeDelimiterValues
  {
    [EnumString("centered")]
    Centered = 0,
    [EnumString("match")]
    Match = 1,
  }
}

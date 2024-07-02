using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("Orientation")]
  public enum OrientationValues
  {
    [EnumString("maxMin")]
    MaxMin = 0,
    [EnumString("minMax")]
    MinMax = 1,
  }
}

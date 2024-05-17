using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("Shape")]
  public enum ShapeValues
  {
    [EnumString("cone")]
    Cone = 0,
    [EnumString("coneToMax")]
    ConeToMax = 1,
    [EnumString("box")]
    Box = 2,
    [EnumString("cylinder")]
    Cylinder = 3,
    [EnumString("pyramid")]
    Pyramid = 4,
    [EnumString("pyramidToMax")]
    PyramidToMax,
  }
}

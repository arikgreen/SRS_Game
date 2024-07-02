using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("CenterShapeMapping")]
  public enum CenterShapeMappingValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("fNode")]
    FNode,
  }
}

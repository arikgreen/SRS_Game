using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("NodeHorizontalAlignment")]
  public enum NodeHorizontalAlignmentValues
  {
    [EnumString("l")]
    L,
    [EnumString("ctr")]
    Ctr,
    [EnumString("r")]
    R,
  }
}

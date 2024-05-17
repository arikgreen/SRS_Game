using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("DiagramHorizontalAlignment")]
  public enum HorizontalAlignmentValues
  {
    [EnumString("l")]
    L,
    [EnumString("ctr")]
    Ctr,
    [EnumString("r")]
    R,
    [EnumString("none")]
    None = 3,
  }
}

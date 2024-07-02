using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("VerticalAlignment")]
  public enum VerticalAlignmentValues
  {
    [EnumString("t")]
    T,
    [EnumString("mid")]
    Mid,
    [EnumString("b")]
    B,
    [EnumString("none")]
    None = 3,
  }
}

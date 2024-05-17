using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("NodeVerticalAlignment")]
  public enum NodeVerticalAlignmentValues
  {
    [EnumString("t")]
    T,
    [EnumString("mid")]
    Mid,
    [EnumString("b")]
    B,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("SecondaryChildAlignment")]
  public enum SecondaryChildAlignmentValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("t")]
    T,
    [EnumString("b")]
    B,
    [EnumString("l")]
    L,
    [EnumString("r")]
    R,
  }
}

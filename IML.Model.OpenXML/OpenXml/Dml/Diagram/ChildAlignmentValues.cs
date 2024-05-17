using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ChildAlignment")]
  public enum ChildAlignmentValues
  {
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

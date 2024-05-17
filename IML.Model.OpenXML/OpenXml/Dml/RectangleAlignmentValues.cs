using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("RectAlignment")]
  public enum RectangleAlignmentValues
  {
    [EnumString("tl")]
    Tl,
    [EnumString("t")]
    T,
    [EnumString("tr")]
    Tr,
    [EnumString("l")]
    L,
    [EnumString("ctr")]
    Ctr,
    [EnumString("r")]
    R,
    [EnumString("bl")]
    Bl,
    [EnumString("b")]
    B,
    [EnumString("br")]
    Br,
  }
}

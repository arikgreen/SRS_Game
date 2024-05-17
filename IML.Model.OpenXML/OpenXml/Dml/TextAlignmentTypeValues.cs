using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextAlignType")]
  public enum TextAlignmentTypeValues
  {
    [EnumString("l")]
    L,
    [EnumString("ctr")]
    Ctr,
    [EnumString("r")]
    R,
    [EnumString("just")]
    Just,
    [EnumString("justLow")]
    JustLow,
    [EnumString("dist")]
    Dist,
    [EnumString("thaiDist")]
    ThaiDist,
  }
}

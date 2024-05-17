using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextTabAlignType")]
  public enum TextTabAlignmentValues
  {
    [EnumString("l")]
    L,
    [EnumString("ctr")]
    Ctr,
    [EnumString("r")]
    R,
    [EnumString("dec")]
    Dec,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("LineEndType")]
  public enum LineEndValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("triangle")]
    Triangle = 1,
    [EnumString("stealth")]
    Stealth = 2,
    [EnumString("diamond")]
    Diamond = 3,
    [EnumString("oval")]
    Oval = 4,
    [EnumString("arrow")]
    Arrow = 5,
  }
}

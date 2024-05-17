using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextUnderlineType")]
  public enum TextUnderlineValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("words")]
    Words = 1,
    [EnumString("sng")]
    Sng,
    [EnumString("dbl")]
    Dbl,
    [EnumString("heavy")]
    Heavy = 4,
    [EnumString("dotted")]
    Dotted = 5,
    [EnumString("dottedHeavy")]
    DottedHeavy,
    [EnumString("dash")]
    Dash = 7,
    [EnumString("dashHeavy")]
    DashHeavy = 8,
    [EnumString("dashLong")]
    DashLong = 9,
    [EnumString("dashLongHeavy")]
    DashLongHeavy = 10,
    [EnumString("dotDash")]
    DotDash = 11,
    [EnumString("dotDashHeavy")]
    DotDashHeavy = 12,
    [EnumString("dotDotDash")]
    DotDotDash = 13,
    [EnumString("dotDotDashHeavy")]
    DotDotDashHeavy = 14,
    [EnumString("wavy")]
    Wavy = 15,
    [EnumString("wavyHeavy")]
    WavyHeavy = 16,
    [EnumString("wavyDbl")]
    WavyDbl,
  }
}

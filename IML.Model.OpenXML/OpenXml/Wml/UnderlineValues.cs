using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Underline")]
  public enum UnderlineValues
  {
    [EnumString("single")]
    Single = 0,
    [EnumString("words")]
    Words = 1,
    [EnumString("double")]
    Double = 2,
    [EnumString("thick")]
    Thick = 3,
    [EnumString("dotted")]
    Dotted = 4,
    [EnumString("dottedHeavy")]
    DottedHeavy = 5,
    [EnumString("dash")]
    Dash = 6,
    [EnumString("dashedHeavy")]
    DashedHeavy = 7,
    [EnumString("dashLong")]
    DashLong = 8,
    [EnumString("dashLongHeavy")]
    DashLongHeavy = 9,
    [EnumString("dotDash")]
    DotDash = 10,
    [EnumString("dashDotHeavy")]
    DashDotHeavy = 11,
    [EnumString("dotDotDash")]
    DotDotDash = 12,
    [EnumString("dashDotDotHeavy")]
    DashDotDotHeavy = 13,
    [EnumString("wave")]
    Wave = 14,
    [EnumString("wavyHeavy")]
    WavyHeavy = 15,
    [EnumString("wavyDouble")]
    WavyDouble = 16,
    [EnumString("none")]
    None = 17,
  }
}

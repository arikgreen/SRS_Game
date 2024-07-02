using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("BevelPresetType")]
  public enum BevelPresetValues
  {
    [EnumString("relaxedInset")]
    RelaxedInset = 0,
    [EnumString("circle")]
    Circle = 1,
    [EnumString("slope")]
    Slope = 2,
    [EnumString("cross")]
    Cross = 3,
    [EnumString("angle")]
    Angle = 4,
    [EnumString("softRound")]
    SoftRound = 5,
    [EnumString("convex")]
    Convex = 6,
    [EnumString("coolSlant")]
    CoolSlant = 7,
    [EnumString("divot")]
    Divot = 8,
    [EnumString("riblet")]
    Riblet = 9,
    [EnumString("hardEdge")]
    HardEdge = 10,
    [EnumString("artDeco")]
    ArtDeco = 11,
  }
}

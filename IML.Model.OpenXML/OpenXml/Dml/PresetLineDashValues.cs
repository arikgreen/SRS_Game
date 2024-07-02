using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PresetLineDashVal")]
  public enum PresetLineDashValues
  {
    [EnumString("solid")]
    Solid = 0,
    [EnumString("dot")]
    Dot = 1,
    [EnumString("dash")]
    Dash = 2,
    [EnumString("lgDash")]
    LgDash,
    [EnumString("dashDot")]
    DashDot = 4,
    [EnumString("lgDashDot")]
    LgDashDot,
    [EnumString("lgDashDotDot")]
    LgDashDotDot,
    [EnumString("sysDash")]
    SysDash,
    [EnumString("sysDot")]
    SysDot,
    [EnumString("sysDashDot")]
    SysDashDot,
    [EnumString("sysDashDotDot")]
    SysDashDotDot,
  }
}

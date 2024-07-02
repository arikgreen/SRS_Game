using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("AutoTextRotation")]
  public enum AutoTextRotationValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("upr")]
    Upr,
    [EnumString("grav")]
    Grav,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("AnimLvlStr")]
  public enum AnimationLevelStringValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("lvl")]
    Lvl,
    [EnumString("ctr")]
    Ctr,
  }
}

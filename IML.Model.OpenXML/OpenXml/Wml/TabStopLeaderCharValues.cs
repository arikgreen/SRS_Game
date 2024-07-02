using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TabTlc")]
  public enum TabStopLeaderCharValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("dot")]
    Dot = 1,
    [EnumString("hyphen")]
    Hyphen = 2,
    [EnumString("underscore")]
    Underscore = 3,
    [EnumString("heavy")]
    Heavy = 4,
    [EnumString("middleDot")]
    MiddleDot = 5,
  }
}

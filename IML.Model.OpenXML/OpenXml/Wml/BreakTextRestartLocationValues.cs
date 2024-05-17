using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("BrClear")]
  public enum BreakTextRestartLocationValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("left")]
    Left = 1,
    [EnumString("right")]
    Right = 2,
    [EnumString("all")]
    All = 3,
  }
}

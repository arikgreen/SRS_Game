using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("BreakBin")]
  public enum BreakBinaryOperatorValues
  {
    [EnumString("before")]
    Before = 0,
    [EnumString("after")]
    After = 1,
    [EnumString("repeat")]
    Repeat = 2,
  }
}

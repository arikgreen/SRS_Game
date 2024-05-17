using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("BreakBinSub")]
  public enum BreakBinarySubtractionValues
  {
    [EnumString("--")]
    MinusMinus = 0,
    [EnumString("-+")]
    MinusPlus = 1,
    [EnumString("+-")]
    PlusMinus = 2,
  }
}

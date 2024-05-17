using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("TrendlineType")]
  public enum TrendlineValues
  {
    [EnumString("exp")]
    Exp,
    [EnumString("linear")]
    Linear = 1,
    [EnumString("log")]
    Log,
    [EnumString("movingAvg")]
    MovingAvg,
    [EnumString("poly")]
    Poly,
    [EnumString("power")]
    Power = 5,
  }
}

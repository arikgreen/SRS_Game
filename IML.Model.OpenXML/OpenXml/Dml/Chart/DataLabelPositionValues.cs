using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("DLblPos")]
  public enum DataLabelPositionValues
  {
    [EnumString("bestFit")]
    BestFit = 0,
    [EnumString("b")]
    B,
    [EnumString("ctr")]
    Ctr,
    [EnumString("inBase")]
    InBase,
    [EnumString("inEnd")]
    InEnd,
    [EnumString("l")]
    L,
    [EnumString("outEnd")]
    OutEnd,
    [EnumString("r")]
    R,
    [EnumString("t")]
    T,
  }
}

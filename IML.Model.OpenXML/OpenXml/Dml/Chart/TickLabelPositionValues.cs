using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("TickLblPos")]
  public enum TickLabelPositionValues
  {
    [EnumString("high")]
    High = 0,
    [EnumString("low")]
    Low = 1,
    [EnumString("nextTo")]
    NextTo = 2,
    [EnumString("none")]
    None = 3,
  }
}

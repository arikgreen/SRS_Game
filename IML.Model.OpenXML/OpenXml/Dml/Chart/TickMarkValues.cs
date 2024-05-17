using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("TickMark")]
  public enum TickMarkValues
  {
    [EnumString("cross")]
    Cross = 0,
    [EnumString("in")]
    In,
    [EnumString("none")]
    None = 2,
    [EnumString("out")]
    Out,
  }
}

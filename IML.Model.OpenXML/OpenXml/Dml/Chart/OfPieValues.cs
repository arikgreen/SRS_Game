using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("OfPieType")]
  public enum OfPieValues
  {
    [EnumString("pie")]
    Pie = 0,
    [EnumString("bar")]
    Bar = 1,
  }
}

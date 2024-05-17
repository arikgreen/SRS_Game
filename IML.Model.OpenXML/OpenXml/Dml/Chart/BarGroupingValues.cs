using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("BarGrouping")]
  public enum BarGroupingValues
  {
    [EnumString("percentStacked")]
    PercentStacked = 0,
    [EnumString("clustered")]
    Clustered = 1,
    [EnumString("standard")]
    Standard = 2,
    [EnumString("stacked")]
    Stacked = 3,
  }
}

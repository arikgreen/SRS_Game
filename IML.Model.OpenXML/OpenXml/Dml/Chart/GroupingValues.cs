using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("Grouping")]
  public enum GroupingValues
  {
    [EnumString("percentStacked")]
    PercentStacked = 0,
    [EnumString("standard")]
    Standard = 1,
    [EnumString("stacked")]
    Stacked = 2,
  }
}

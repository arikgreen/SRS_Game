using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("ChartBuildStep")]
  public enum ChartBuildStepValues
  {
    [EnumString("category")]
    Category = 0,
    [EnumString("ptInCategory")]
    PtInCategory,
    [EnumString("series")]
    Series = 2,
    [EnumString("ptInSeries")]
    PtInSeries,
    [EnumString("allPts")]
    AllPts,
    [EnumString("gridLegend")]
    GridLegend = 5,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("AnimationChartOnlyBuildType")]
  public enum AnimationChartOnlyBuildValues
  {
    [EnumString("series")]
    Series = 0,
    [EnumString("category")]
    Category = 1,
    [EnumString("seriesEl")]
    SeriesEl,
    [EnumString("categoryEl")]
    CategoryEl,
  }
}

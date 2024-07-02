using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("animationChartBuildProperties")]
  [Alias("AnimationChartBuildProperties")]
  public class AnimationChartBuildPropertiesType
  {
    [Tag("animationChartBuildType")]
    AnimationChartBuildTypeValue Bld{ get; set; }

    [Tag("boolean")]
    Boolean AnimBg{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("gradientStop")]
  [Alias("GradientStop")]
  public class GradientStop
  {
    [Tag("positiveFixedPercentage")]
    PositiveFixedPercentageValue Pos{ get; set; }

  }
}

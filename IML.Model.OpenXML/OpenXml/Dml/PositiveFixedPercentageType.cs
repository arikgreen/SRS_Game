using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("positiveFixedPercentage")]
  [Alias("PositiveFixedPercentage")]
  public class PositiveFixedPercentageType
  {
    [Tag("positiveFixedPercentage")]
    PositiveFixedPercentageValue Val{ get; set; }

  }
}

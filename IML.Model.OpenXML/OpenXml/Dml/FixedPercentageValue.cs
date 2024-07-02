using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("fixedPercentage")]
  [Alias("FixedPercentage")]
  public class FixedPercentageValue
  {
    [Tag("fixedPercentage")]
    FixedPercentageValue Val{ get; set; }

  }
}

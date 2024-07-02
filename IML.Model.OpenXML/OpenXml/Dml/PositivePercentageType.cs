using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("positivePercentage")]
  [Alias("PositivePercentage")]
  public class PositivePercentageType
  {
    [Tag("positivePercentage")]
    PositivePercentageValue Val{ get; set; }

  }
}

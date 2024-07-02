using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("percentage")]
  [Alias("Percentage")]
  public class PercentageType
  {
    [Tag("percentage")]
    PercentageValue Val{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("hPercent")]
  [Alias("HPercent")]
  public class HeightPercent
  {
    [Tag("hPercent")]
    HPercentValue Val{ get; set; }

  }
}

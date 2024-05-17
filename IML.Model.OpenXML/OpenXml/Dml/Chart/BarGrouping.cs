using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("barGrouping")]
  [Alias("BarGrouping")]
  public class BarGrouping
  {
    [Tag("barGrouping")]
    BarGroupingValues Val{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("barDir")]
  [Alias("BarDir")]
  public class BarDirection
  {
    [Tag("barDir")]
    BarDirectionValues Val{ get; set; }

  }
}

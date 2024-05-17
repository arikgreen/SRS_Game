using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("timeUnit")]
  [Alias("TimeUnit")]
  public class TimeUnitType
  {
    [Tag("timeUnit")]
    TimeUnitValues Val{ get; set; }

  }
}

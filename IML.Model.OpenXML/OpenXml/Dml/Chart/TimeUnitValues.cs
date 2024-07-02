using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("TimeUnit")]
  public enum TimeUnitValues
  {
    [EnumString("days")]
    Days = 0,
    [EnumString("months")]
    Months = 1,
    [EnumString("years")]
    Years = 2,
  }
}

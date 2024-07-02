using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("ErrValType")]
  public enum ErrorValues
  {
    [EnumString("cust")]
    Cust,
    [EnumString("fixedVal")]
    FixedVal,
    [EnumString("percentage")]
    Percentage = 2,
    [EnumString("stdDev")]
    StdDev,
    [EnumString("stdErr")]
    StdErr,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("SplitType")]
  public enum SplitValues
  {
    [EnumString("auto")]
    Auto,
    [EnumString("cust")]
    Cust,
    [EnumString("percent")]
    Percent = 1,
    [EnumString("pos")]
    Pos,
    [EnumString("val")]
    Val,
  }
}

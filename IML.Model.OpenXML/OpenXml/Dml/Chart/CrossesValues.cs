using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("Crosses")]
  public enum CrossesValues
  {
    [EnumString("autoZero")]
    AutoZero = 0,
    [EnumString("max")]
    Max,
    [EnumString("min")]
    Min,
  }
}

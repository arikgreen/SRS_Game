using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Direction")]
  public enum DirectionValues
  {
    [EnumString("ltr")]
    Ltr = 0,
    [EnumString("rtl")]
    Rtl = 1,
  }
}

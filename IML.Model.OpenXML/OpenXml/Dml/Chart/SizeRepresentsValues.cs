using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("SizeRepresents")]
  public enum SizeRepresentsValues
  {
    [EnumString("area")]
    Area = 0,
    [EnumString("w")]
    W,
  }
}

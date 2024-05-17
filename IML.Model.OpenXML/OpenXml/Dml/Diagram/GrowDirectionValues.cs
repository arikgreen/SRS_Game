using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("GrowDirection")]
  public enum GrowDirectionValues
  {
    [EnumString("tL")]
    TL,
    [EnumString("tR")]
    TR,
    [EnumString("bL")]
    BL,
    [EnumString("bR")]
    BR,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("SecondaryLinearDirection")]
  public enum SecondaryLinearDirectionValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("fromL")]
    FromL,
    [EnumString("fromR")]
    FromR,
    [EnumString("fromT")]
    FromT,
    [EnumString("fromB")]
    FromB,
  }
}

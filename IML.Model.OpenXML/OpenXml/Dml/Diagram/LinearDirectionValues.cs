using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("LinearDirection")]
  public enum LinearDirectionValues
  {
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

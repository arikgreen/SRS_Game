using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ConnectorPoint")]
  public enum ConnectorPointValues
  {
    [EnumString("auto")]
    Auto = 0,
    [EnumString("bCtr")]
    BCtr,
    [EnumString("ctr")]
    Ctr,
    [EnumString("midL")]
    MidL,
    [EnumString("midR")]
    MidR,
    [EnumString("tCtr")]
    TCtr,
    [EnumString("bL")]
    BL,
    [EnumString("bR")]
    BR,
    [EnumString("tL")]
    TL,
    [EnumString("tR")]
    TR,
    [EnumString("radial")]
    Radial = 10,
  }
}

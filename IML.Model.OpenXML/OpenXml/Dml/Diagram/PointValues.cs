using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("PtType")]
  public enum PointValues
  {
    [EnumString("node")]
    Node = 0,
    [EnumString("asst")]
    Asst,
    [EnumString("doc")]
    Doc,
    [EnumString("pres")]
    Pres,
    [EnumString("parTrans")]
    ParTrans,
    [EnumString("sibTrans")]
    SibTrans,
  }
}

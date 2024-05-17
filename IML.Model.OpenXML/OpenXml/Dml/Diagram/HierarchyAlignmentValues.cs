using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("HierarchyAlignment")]
  public enum HierarchyAlignmentValues
  {
    [EnumString("tL")]
    TL,
    [EnumString("tR")]
    TR,
    [EnumString("tCtrCh")]
    TCtrCh,
    [EnumString("tCtrDes")]
    TCtrDes,
    [EnumString("bL")]
    BL,
    [EnumString("bR")]
    BR,
    [EnumString("bCtrCh")]
    BCtrCh,
    [EnumString("bCtrDes")]
    BCtrDes,
    [EnumString("lT")]
    LT,
    [EnumString("lB")]
    LB,
    [EnumString("lCtrCh")]
    LCtrCh,
    [EnumString("lCtrDes")]
    LCtrDes,
    [EnumString("rT")]
    RT,
    [EnumString("rB")]
    RB,
    [EnumString("rCtrCh")]
    RCtrCh,
    [EnumString("rCtrDes")]
    RCtrDes,
  }
}

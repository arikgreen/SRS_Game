using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("AxisType")]
  public enum AxisValues
  {
    [EnumString("self")]
    Self = 0,
    [EnumString("ch")]
    Ch,
    [EnumString("des")]
    Des,
    [EnumString("desOrSelf")]
    DesOrSelf,
    [EnumString("par")]
    Par,
    [EnumString("ancst")]
    Ancst,
    [EnumString("ancstOrSelf")]
    AncstOrSelf,
    [EnumString("followSib")]
    FollowSib,
    [EnumString("precedSib")]
    PrecedSib,
    [EnumString("follow")]
    Follow = 9,
    [EnumString("preced")]
    Preced,
    [EnumString("root")]
    Root = 11,
    [EnumString("none")]
    None = 12,
  }
}

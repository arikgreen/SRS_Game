using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("CompoundLine")]
  public enum CompoundLineValues
  {
    [EnumString("sng")]
    Sng,
    [EnumString("dbl")]
    Dbl,
    [EnumString("thickThin")]
    ThickThin = 2,
    [EnumString("thinThick")]
    ThinThick = 3,
    [EnumString("tri")]
    Tri,
  }
}

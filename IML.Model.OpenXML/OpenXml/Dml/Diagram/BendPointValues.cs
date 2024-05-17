using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("BendPoint")]
  public enum BendPointValues
  {
    [EnumString("beg")]
    Beg,
    [EnumString("def")]
    Def,
    [EnumString("end")]
    End = 2,
  }
}

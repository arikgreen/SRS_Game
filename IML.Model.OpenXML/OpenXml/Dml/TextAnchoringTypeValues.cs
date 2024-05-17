using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextAnchoringType")]
  public enum TextAnchoringTypeValues
  {
    [EnumString("t")]
    T,
    [EnumString("ctr")]
    Ctr,
    [EnumString("b")]
    B,
    [EnumString("just")]
    Just,
    [EnumString("dist")]
    Dist,
  }
}

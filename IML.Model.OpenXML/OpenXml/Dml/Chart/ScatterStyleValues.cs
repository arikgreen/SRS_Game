using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("ScatterStyle")]
  public enum ScatterStyleValues
  {
    [EnumString("none")]
    None,
    [EnumString("line")]
    Line = 0,
    [EnumString("lineMarker")]
    LineMarker = 1,
    [EnumString("marker")]
    Marker = 2,
    [EnumString("smooth")]
    Smooth = 3,
    [EnumString("smoothMarker")]
    SmoothMarker = 4,
  }
}

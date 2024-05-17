using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PathShadeType")]
  public enum PathShadeValues
  {
    [EnumString("shape")]
    Shape = 0,
    [EnumString("circle")]
    Circle = 1,
    [EnumString("rect")]
    Rect,
  }
}

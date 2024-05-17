using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("LayoutTarget")]
  public enum LayoutTargetValues
  {
    [EnumString("inner")]
    Inner = 0,
    [EnumString("outer")]
    Outer = 1,
  }
}

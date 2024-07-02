using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("LayoutMode")]
  public enum LayoutModeValues
  {
    [EnumString("edge")]
    Edge = 0,
    [EnumString("factor")]
    Factor = 1,
  }
}

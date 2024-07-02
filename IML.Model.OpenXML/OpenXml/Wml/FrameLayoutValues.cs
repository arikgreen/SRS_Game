using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("FrameLayout")]
  public enum FrameLayoutValues
  {
    [EnumString("rows")]
    Rows = 0,
    [EnumString("cols")]
    Cols,
    [EnumString("none")]
    None = 2,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("TopBot")]
  public enum VerticalAlignmentValues
  {
    [EnumString("top")]
    Top = 0,
    [EnumString("bot")]
    Bot = 3,
  }
}

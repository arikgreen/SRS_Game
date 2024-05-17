using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("Jc")]
  public enum JustificationValues
  {
    [EnumString("left")]
    Left = 0,
    [EnumString("right")]
    Right = 1,
    [EnumString("center")]
    Center = 2,
    [EnumString("centerGroup")]
    CenterGroup = 3,
  }
}

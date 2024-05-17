using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("RubyAlign")]
  public enum RubyAlignValues
  {
    [EnumString("center")]
    Center = 0,
    [EnumString("distributeLetter")]
    DistributeLetter = 1,
    [EnumString("distributeSpace")]
    DistributeSpace = 2,
    [EnumString("left")]
    Left = 3,
    [EnumString("right")]
    Right = 4,
    [EnumString("rightVertical")]
    RightVertical = 5,
  }
}

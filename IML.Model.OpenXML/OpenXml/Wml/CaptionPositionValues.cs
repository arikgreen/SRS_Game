using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("CaptionPos")]
  public enum CaptionPositionValues
  {
    [EnumString("above")]
    Above = 0,
    [EnumString("below")]
    Below = 1,
    [EnumString("left")]
    Left,
    [EnumString("right")]
    Right,
  }
}

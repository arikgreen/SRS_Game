using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("CombineBrackets")]
  public enum CombineBracketValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("round")]
    Round = 1,
    [EnumString("square")]
    Square = 2,
    [EnumString("angle")]
    Angle = 3,
    [EnumString("curly")]
    Curly = 4,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Em")]
  public enum EmphasisMarkValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("dot")]
    Dot = 1,
    [EnumString("comma")]
    Comma = 2,
    [EnumString("circle")]
    Circle = 3,
    [EnumString("underDot")]
    UnderDot = 4,
  }
}

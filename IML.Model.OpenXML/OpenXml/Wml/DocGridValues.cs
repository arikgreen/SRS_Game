using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DocGrid")]
  public enum DocGridValues
  {
    [EnumString("default")]
    Default = 0,
    [EnumString("lines")]
    Lines = 1,
    [EnumString("linesAndChars")]
    LinesAndChars = 2,
    [EnumString("snapToChars")]
    SnapToChars = 3,
  }
}

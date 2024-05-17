using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("Style")]
  public enum StyleValues
  {
    [EnumString("p")]
    P,
    [EnumString("b")]
    B,
    [EnumString("i")]
    I,
    [EnumString("bi")]
    Bi,
  }
}

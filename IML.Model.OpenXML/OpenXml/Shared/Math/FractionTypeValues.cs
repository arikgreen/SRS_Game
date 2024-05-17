using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("FType")]
  public enum FractionTypeValues
  {
    [EnumString("bar")]
    Bar = 0,
    [EnumString("skw")]
    Skw,
    [EnumString("lin")]
    Lin,
    [EnumString("noBar")]
    NoBar = 3,
  }
}

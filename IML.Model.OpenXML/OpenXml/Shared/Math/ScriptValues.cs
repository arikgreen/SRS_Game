using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("Script")]
  public enum ScriptValues
  {
    [EnumString("roman")]
    Roman = 0,
    [EnumString("script")]
    Script = 1,
    [EnumString("fraktur")]
    Fraktur = 2,
    [EnumString("double-struck")]
    DoubleStruck = 3,
    [EnumString("sans-serif")]
    SansSerif = 4,
    [EnumString("monospace")]
    Monospace = 5,
  }
}

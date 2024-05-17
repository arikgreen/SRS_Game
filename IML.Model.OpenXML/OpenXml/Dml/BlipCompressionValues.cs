using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("BlipCompression")]
  public enum BlipCompressionValues
  {
    [EnumString("email")]
    Email = 0,
    [EnumString("screen")]
    Screen = 1,
    [EnumString("print")]
    Print = 2,
    [EnumString("hqprint")]
    Hqprint,
    [EnumString("none")]
    None = 4,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Wrap")]
  public enum TextWrappingValues
  {
    [EnumString("auto")]
    Auto = 0,
    [EnumString("notBeside")]
    NotBeside = 1,
    [EnumString("around")]
    Around = 2,
    [EnumString("tight")]
    Tight = 3,
    [EnumString("through")]
    Through = 4,
    [EnumString("none")]
    None = 5,
  }
}

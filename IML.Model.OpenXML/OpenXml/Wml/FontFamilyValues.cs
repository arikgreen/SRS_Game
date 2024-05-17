using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("FontFamily")]
  public enum FontFamilyValues
  {
    [EnumString("decorative")]
    Decorative = 0,
    [EnumString("modern")]
    Modern = 1,
    [EnumString("roman")]
    Roman = 2,
    [EnumString("script")]
    Script = 3,
    [EnumString("swiss")]
    Swiss = 4,
    [EnumString("auto")]
    Auto = 5,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextFontAlignType")]
  public enum TextFontAlignmentValues
  {
    [EnumString("auto")]
    Auto,
    [EnumString("t")]
    T,
    [EnumString("ctr")]
    Ctr,
    [EnumString("base")]
    Base,
    [EnumString("b")]
    B,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("BlackWhiteMode")]
  public enum BlackWhiteModeValues
  {
    [EnumString("clr")]
    Clr,
    [EnumString("auto")]
    Auto = 1,
    [EnumString("gray")]
    Gray = 2,
    [EnumString("ltGray")]
    LtGray,
    [EnumString("invGray")]
    InvGray = 4,
    [EnumString("grayWhite")]
    GrayWhite = 5,
    [EnumString("blackGray")]
    BlackGray = 6,
    [EnumString("blackWhite")]
    BlackWhite = 7,
    [EnumString("black")]
    Black = 8,
    [EnumString("white")]
    White = 9,
    [EnumString("hidden")]
    Hidden = 10,
  }
}

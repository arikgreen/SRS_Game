using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Theme")]
  public enum ThemeFontValues
  {
    [EnumString("majorEastAsia")]
    MajorEastAsia = 0,
    [EnumString("majorBidi")]
    MajorBidi = 1,
    [EnumString("majorAscii")]
    MajorAscii = 2,
    [EnumString("majorHAnsi")]
    MajorHAnsi,
    [EnumString("minorEastAsia")]
    MinorEastAsia = 4,
    [EnumString("minorBidi")]
    MinorBidi = 5,
    [EnumString("minorAscii")]
    MinorAscii = 6,
    [EnumString("minorHAnsi")]
    MinorHAnsi,
  }
}

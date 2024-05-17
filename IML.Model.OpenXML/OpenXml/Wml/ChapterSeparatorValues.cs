using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("ChapterSep")]
  public enum ChapterSeparatorValues
  {
    [EnumString("hyphen")]
    Hyphen = 0,
    [EnumString("period")]
    Period = 1,
    [EnumString("colon")]
    Colon = 2,
    [EnumString("emDash")]
    EmDash = 3,
    [EnumString("enDash")]
    EnDash = 4,
  }
}

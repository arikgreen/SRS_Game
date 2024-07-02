using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TextAlignment")]
  public enum VerticalTextAlignmentValues
  {
    [EnumString("top")]
    Top = 0,
    [EnumString("center")]
    Center = 1,
    [EnumString("baseline")]
    Baseline = 2,
    [EnumString("bottom")]
    Bottom = 3,
    [EnumString("auto")]
    Auto = 4,
  }
}

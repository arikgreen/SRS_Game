using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Alias("AlignV")]
  public enum VerticalAlignmentValues
  {
    [EnumString("top")]
    Top = 0,
    [EnumString("bottom")]
    Bottom = 1,
    [EnumString("center")]
    Center = 2,
    [EnumString("inside")]
    Inside = 3,
    [EnumString("outside")]
    Outside = 4,
  }
}

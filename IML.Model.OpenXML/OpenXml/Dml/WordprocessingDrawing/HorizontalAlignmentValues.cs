using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Alias("AlignH")]
  public enum HorizontalAlignmentValues
  {
    [EnumString("left")]
    Left = 0,
    [EnumString("right")]
    Right = 1,
    [EnumString("center")]
    Center = 2,
    [EnumString("inside")]
    Inside = 3,
    [EnumString("outside")]
    Outside = 4,
  }
}

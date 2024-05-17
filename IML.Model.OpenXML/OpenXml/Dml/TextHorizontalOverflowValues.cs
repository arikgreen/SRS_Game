using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextHorzOverflowType")]
  public enum TextHorizontalOverflowValues
  {
    [EnumString("overflow")]
    Overflow = 0,
    [EnumString("clip")]
    Clip = 1,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextVertOverflowType")]
  public enum TextVerticalOverflowValues
  {
    [EnumString("overflow")]
    Overflow = 0,
    [EnumString("ellipsis")]
    Ellipsis = 1,
    [EnumString("clip")]
    Clip = 2,
  }
}

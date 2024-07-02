using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextWrappingType")]
  public enum TextWrappingValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("square")]
    Square = 1,
  }
}

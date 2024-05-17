using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextCapsType")]
  public enum TextCapsValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("small")]
    Small = 1,
    [EnumString("all")]
    All = 2,
  }
}

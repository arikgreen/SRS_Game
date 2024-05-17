using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ClrAppMethod")]
  public enum ColorApplicationMethodValues
  {
    [EnumString("span")]
    Span = 0,
    [EnumString("cycle")]
    Cycle = 1,
    [EnumString("repeat")]
    Repeat = 2,
  }
}

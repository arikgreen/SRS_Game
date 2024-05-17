using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PTabAlignment")]
  public enum TableRowAlignmentValues
  {
    [EnumString("left")]
    Left = 0,
    [EnumString("center")]
    Center = 1,
    [EnumString("right")]
    Right = 2,
  }
}

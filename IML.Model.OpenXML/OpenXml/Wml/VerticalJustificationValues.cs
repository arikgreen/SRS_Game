using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("VerticalJc")]
  public enum VerticalJustificationValues
  {
    [EnumString("top")]
    Top = 0,
    [EnumString("center")]
    Center = 1,
    [EnumString("both")]
    Both = 2,
    [EnumString("bottom")]
    Bottom = 3,
  }
}

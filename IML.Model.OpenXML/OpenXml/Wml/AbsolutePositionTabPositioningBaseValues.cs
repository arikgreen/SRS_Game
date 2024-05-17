using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PTabRelativeTo")]
  public enum AbsolutePositionTabPositioningBaseValues
  {
    [EnumString("margin")]
    Margin = 0,
    [EnumString("indent")]
    Indent = 1,
  }
}

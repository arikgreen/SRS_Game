using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Alias("RelFromH")]
  public enum HorizontalRelativePositionValues
  {
    [EnumString("margin")]
    Margin = 0,
    [EnumString("page")]
    Page = 1,
    [EnumString("column")]
    Column = 2,
    [EnumString("character")]
    Character = 3,
    [EnumString("leftMargin")]
    LeftMargin = 4,
    [EnumString("rightMargin")]
    RightMargin = 5,
    [EnumString("insideMargin")]
    InsideMargin = 6,
    [EnumString("outsideMargin")]
    OutsideMargin = 7,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Alias("RelFromV")]
  public enum VerticalRelativePositionValues
  {
    [EnumString("margin")]
    Margin = 0,
    [EnumString("page")]
    Page = 1,
    [EnumString("paragraph")]
    Paragraph = 2,
    [EnumString("line")]
    Line = 3,
    [EnumString("topMargin")]
    TopMargin = 4,
    [EnumString("bottomMargin")]
    BottomMargin = 5,
    [EnumString("insideMargin")]
    InsideMargin = 6,
    [EnumString("outsideMargin")]
    OutsideMargin = 7,
  }
}

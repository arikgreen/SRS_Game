using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("VAnchor")]
  public enum VerticalAnchorValues
  {
    [EnumString("text")]
    Text = 0,
    [EnumString("margin")]
    Margin = 1,
    [EnumString("page")]
    Page = 2,
  }
}

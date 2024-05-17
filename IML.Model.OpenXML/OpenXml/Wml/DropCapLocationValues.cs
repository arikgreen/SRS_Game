using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DropCap")]
  public enum DropCapLocationValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("drop")]
    Drop = 1,
    [EnumString("margin")]
    Margin = 2,
  }
}

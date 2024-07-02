using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("BrType")]
  public enum BreakValues
  {
    [EnumString("page")]
    Page = 0,
    [EnumString("column")]
    Column = 1,
    [EnumString("textWrapping")]
    TextWrapping = 2,
  }
}

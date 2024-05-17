using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Merge")]
  public enum MergedCellValues
  {
    [EnumString("continue")]
    Continue = 0,
    [EnumString("restart")]
    Restart = 1,
  }
}

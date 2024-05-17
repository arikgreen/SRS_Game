using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TblOverlap")]
  public enum TableOverlapValues
  {
    [EnumString("never")]
    Never = 0,
    [EnumString("overlap")]
    Overlap = 1,
  }
}

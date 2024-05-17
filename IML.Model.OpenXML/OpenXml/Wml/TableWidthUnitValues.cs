using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TblWidth")]
  public enum TableWidthUnitValues
  {
    [EnumString("nil")]
    Nil = 0,
    [EnumString("pct")]
    Pct = 1,
    [EnumString("dxa")]
    Dxa = 2,
    [EnumString("auto")]
    Auto = 3,
  }
}

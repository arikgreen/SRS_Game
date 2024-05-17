using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("HdrFtr")]
  public enum HeaderFooterValues
  {
    [EnumString("even")]
    Even = 0,
    [EnumString("default")]
    Default = 1,
    [EnumString("first")]
    First = 2,
  }
}

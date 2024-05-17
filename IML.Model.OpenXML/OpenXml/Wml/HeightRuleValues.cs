using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("HeightRule")]
  public enum HeightRuleValues
  {
    [EnumString("auto")]
    Auto = 0,
    [EnumString("exact")]
    Exact = 1,
    [EnumString("atLeast")]
    AtLeast = 2,
  }
}

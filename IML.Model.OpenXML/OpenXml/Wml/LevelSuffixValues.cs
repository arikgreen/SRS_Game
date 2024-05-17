using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("LevelSuffix")]
  public enum LevelSuffixValues
  {
    [EnumString("tab")]
    Tab = 0,
    [EnumString("space")]
    Space = 1,
    [EnumString("nothing")]
    Nothing = 2,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("levelSuffix")]
  [Alias("LevelSuffix")]
  public class LevelSuffix
  {
    [Tag("levelSuffix")]
    LevelSuffixValues Val{ get; set; }

  }
}

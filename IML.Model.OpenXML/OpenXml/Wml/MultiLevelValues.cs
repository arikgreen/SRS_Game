using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("MultiLevelType")]
  public enum MultiLevelValues
  {
    [EnumString("singleLevel")]
    SingleLevel = 0,
    [EnumString("multilevel")]
    Multilevel = 1,
    [EnumString("hybridMultilevel")]
    HybridMultilevel = 2,
  }
}

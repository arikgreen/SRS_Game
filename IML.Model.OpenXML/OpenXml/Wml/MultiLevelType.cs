using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("multiLevelType")]
  [Alias("MultiLevelType")]
  public class MultiLevelType
  {
    [Tag("multiLevelType")]
    MultiLevelValues Val{ get; set; }

  }
}

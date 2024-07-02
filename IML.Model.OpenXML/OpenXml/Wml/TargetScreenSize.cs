using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("targetScreenSz")]
  [Alias("TargetScreenSz")]
  public class TargetScreenSize
  {
    [Tag("targetScreenSz")]
    TargetScreenSizeValues Val{ get; set; }

  }
}

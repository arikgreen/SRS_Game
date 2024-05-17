using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("splitType")]
  [Alias("SplitType")]
  public class SplitType
  {
    [Tag("splitType")]
    SplitValues Val{ get; set; }

  }
}

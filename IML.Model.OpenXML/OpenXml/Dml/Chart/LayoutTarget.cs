using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("layoutTarget")]
  [Alias("LayoutTarget")]
  public class LayoutTarget
  {
    [Tag("layoutTarget")]
    LayoutTargetValues Val{ get; set; }

  }
}

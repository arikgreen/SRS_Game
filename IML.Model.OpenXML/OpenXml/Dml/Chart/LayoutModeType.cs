using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("layoutMode")]
  [Alias("LayoutMode")]
  public class LayoutModeType
  {
    [Tag("layoutMode")]
    LayoutModeValues Val{ get; set; }

  }
}

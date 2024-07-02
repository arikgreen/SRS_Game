using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("frameScrollbar")]
  [Alias("FrameScrollbar")]
  public class FrameScrollbar
  {
    [Tag("frameScrollbar")]
    FrameScrollbarVisibilityValues Val{ get; set; }

  }
}

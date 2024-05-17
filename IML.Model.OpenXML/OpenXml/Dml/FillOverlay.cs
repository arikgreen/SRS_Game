using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("fillOverlayEffect")]
  [Alias("FillOverlayEffect")]
  public class FillOverlay
  {
    [Tag("blendMode")]
    BlendModeValues Blend{ get; set; }

  }
}

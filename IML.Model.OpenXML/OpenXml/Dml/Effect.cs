using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("blendEffect")]
  [Alias("BlendEffect")]
  public class Effect
  {
    [Tag("blendMode")]
    BlendModeValues Blend{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("blip")]
  [Alias("Blip")]
  public class Blip
  {
    [Tag("blipCompression")]
    BlipCompressionValues Cstate{ get; set; }

  }
}

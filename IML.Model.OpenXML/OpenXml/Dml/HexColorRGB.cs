using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("sRgbColor")]
  [Alias("SRgbColor")]
  public class HexColorRGB
  {
    [Tag("hexColorRGB")]
    HexColorRGBValue Val{ get; set; }

  }
}

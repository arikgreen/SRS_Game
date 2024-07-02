using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("systemColor")]
  [Alias("SystemColor")]
  public class SystemColor
  {
    [Tag("systemColorVal")]
    SystemColorValues Val{ get; set; }

    [Tag("hexColorRGB")]
    HexColorRGBValue LastClr{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("pixelsMeasure")]
  [Alias("PixelsMeasure")]
  public class PixelsMeasureType
  {
    [Tag("pixelsMeasure")]
    PixelsMeasureValue Val{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("scRgbColor")]
  [Alias("ScRgbColor")]
  public class RgbColorModelPercentage
  {
    [Tag("percentage")]
    PercentageValue R{ get; set; }

    [Tag("percentage")]
    PercentageValue G{ get; set; }

    [Tag("percentage")]
    PercentageValue B{ get; set; }

  }
}

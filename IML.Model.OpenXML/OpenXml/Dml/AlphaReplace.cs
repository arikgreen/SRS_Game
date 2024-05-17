using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("alphaReplaceEffect")]
  [Alias("AlphaReplaceEffect")]
  public class AlphaReplace
  {
    [Tag("positiveFixedPercentage")]
    PositiveFixedPercentageValue A{ get; set; }

  }
}

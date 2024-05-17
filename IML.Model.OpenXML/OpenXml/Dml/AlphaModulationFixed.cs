using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("alphaModulateFixedEffect")]
  [Alias("AlphaModulateFixedEffect")]
  public class AlphaModulationFixed
  {
    [Tag("positivePercentage")]
    PositivePercentageValue Amt{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("crossBetween")]
  [Alias("CrossBetween")]
  public class CrossBetween
  {
    [Tag("crossBetween")]
    CrossBetweenValues Val{ get; set; }

  }
}

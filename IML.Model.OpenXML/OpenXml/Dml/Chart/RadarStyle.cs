using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("radarStyle")]
  [Alias("RadarStyle")]
  public class RadarStyle
  {
    [Tag("radarStyle")]
    RadarStyleValues Val{ get; set; }

  }
}

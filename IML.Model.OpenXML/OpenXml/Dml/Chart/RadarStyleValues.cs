using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("RadarStyle")]
  public enum RadarStyleValues
  {
    [EnumString("standard")]
    Standard = 0,
    [EnumString("marker")]
    Marker = 1,
    [EnumString("filled")]
    Filled = 2,
  }
}

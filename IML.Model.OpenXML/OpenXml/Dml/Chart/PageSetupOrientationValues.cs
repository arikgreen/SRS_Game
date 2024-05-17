using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("PageSetupOrientation")]
  public enum PageSetupOrientationValues
  {
    [EnumString("default")]
    Default = 0,
    [EnumString("portrait")]
    Portrait = 1,
    [EnumString("landscape")]
    Landscape = 2,
  }
}

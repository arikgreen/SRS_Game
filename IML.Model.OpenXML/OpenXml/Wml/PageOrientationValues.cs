using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PageOrientation")]
  public enum PageOrientationValues
  {
    [EnumString("portrait")]
    Portrait = 0,
    [EnumString("landscape")]
    Landscape = 1,
  }
}

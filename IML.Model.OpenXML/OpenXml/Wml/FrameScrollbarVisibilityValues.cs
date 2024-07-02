using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("FrameScrollbar")]
  public enum FrameScrollbarVisibilityValues
  {
    [EnumString("on")]
    On = 0,
    [EnumString("off")]
    Off = 1,
    [EnumString("auto")]
    Auto = 2,
  }
}

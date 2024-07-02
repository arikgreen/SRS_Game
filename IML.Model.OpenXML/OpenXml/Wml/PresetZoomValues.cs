using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Zoom")]
  public enum PresetZoomValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("fullPage")]
    FullPage = 1,
    [EnumString("bestFit")]
    BestFit = 2,
    [EnumString("textFit")]
    TextFit = 3,
  }
}

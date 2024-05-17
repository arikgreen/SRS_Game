using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("ColorSchemeIndex")]
  public enum ColorSchemeIndexValues
  {
    [EnumString("dk1")]
    Dk1,
    [EnumString("lt1")]
    Lt1,
    [EnumString("dk2")]
    Dk2,
    [EnumString("lt2")]
    Lt2,
    [EnumString("accent1")]
    Accent1 = 4,
    [EnumString("accent2")]
    Accent2 = 5,
    [EnumString("accent3")]
    Accent3 = 6,
    [EnumString("accent4")]
    Accent4 = 7,
    [EnumString("accent5")]
    Accent5 = 8,
    [EnumString("accent6")]
    Accent6 = 9,
    [EnumString("hlink")]
    Hlink,
    [EnumString("folHlink")]
    FolHlink,
  }
}

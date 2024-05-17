using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("LineNumberRestart")]
  public enum LineNumberRestartValues
  {
    [EnumString("newPage")]
    NewPage = 0,
    [EnumString("newSection")]
    NewSection = 1,
    [EnumString("continuous")]
    Continuous = 2,
  }
}

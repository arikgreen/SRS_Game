using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Pitch")]
  public enum FontPitchValues
  {
    [EnumString("fixed")]
    Fixed = 0,
    [EnumString("variable")]
    Variable = 1,
    [EnumString("default")]
    Default = 2,
  }
}

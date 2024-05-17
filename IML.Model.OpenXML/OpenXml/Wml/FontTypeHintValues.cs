using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Hint")]
  public enum FontTypeHintValues
  {
    [EnumString("default")]
    Default = 0,
    [EnumString("eastAsia")]
    EastAsia = 1,
    [EnumString("cs")]
    Cs,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("RestartNumber")]
  public enum RestartNumberValues
  {
    [EnumString("continuous")]
    Continuous = 0,
    [EnumString("eachSect")]
    EachSect,
    [EnumString("eachPage")]
    EachPage = 2,
  }
}

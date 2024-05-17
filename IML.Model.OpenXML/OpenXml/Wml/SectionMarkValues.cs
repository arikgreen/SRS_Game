using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("SectionMark")]
  public enum SectionMarkValues
  {
    [EnumString("nextPage")]
    NextPage = 0,
    [EnumString("nextColumn")]
    NextColumn = 1,
    [EnumString("continuous")]
    Continuous = 2,
    [EnumString("evenPage")]
    EvenPage = 3,
    [EnumString("oddPage")]
    OddPage = 4,
  }
}

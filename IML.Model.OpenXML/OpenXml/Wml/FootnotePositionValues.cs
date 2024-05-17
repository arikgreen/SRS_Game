using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("FtnPos")]
  public enum FootnotePositionValues
  {
    [EnumString("pageBottom")]
    PageBottom = 0,
    [EnumString("beneathText")]
    BeneathText = 1,
    [EnumString("sectEnd")]
    SectEnd,
    [EnumString("docEnd")]
    DocEnd,
  }
}

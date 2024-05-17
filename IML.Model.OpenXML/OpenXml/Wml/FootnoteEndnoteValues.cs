using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("FtnEdn")]
  public enum FootnoteEndnoteValues
  {
    [EnumString("normal")]
    Normal = 0,
    [EnumString("separator")]
    Separator = 1,
    [EnumString("continuationSeparator")]
    ContinuationSeparator = 2,
    [EnumString("continuationNotice")]
    ContinuationNotice = 3,
  }
}

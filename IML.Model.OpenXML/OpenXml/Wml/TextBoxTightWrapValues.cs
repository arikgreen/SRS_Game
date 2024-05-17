using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TextboxTightWrap")]
  public enum TextBoxTightWrapValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("allLines")]
    AllLines = 1,
    [EnumString("firstAndLastLine")]
    FirstAndLastLine = 2,
    [EnumString("firstLineOnly")]
    FirstLineOnly = 3,
    [EnumString("lastLineOnly")]
    LastLineOnly = 4,
  }
}

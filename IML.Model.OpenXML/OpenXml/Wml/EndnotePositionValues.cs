using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("EdnPos")]
  public enum EndnotePositionValues
  {
    [EnumString("sectEnd")]
    SectEnd,
    [EnumString("docEnd")]
    DocEnd,
  }
}

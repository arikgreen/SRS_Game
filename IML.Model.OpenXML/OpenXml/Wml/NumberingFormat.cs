using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("numLvl")]
  [Alias("NumLvl")]
  public class NumberingFormat
  {
    [Tag("decimalNumber")]
    DecimalNumberValue Ilvl{ get; set; }

  }
}

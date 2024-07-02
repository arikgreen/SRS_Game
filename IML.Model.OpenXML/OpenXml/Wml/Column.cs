using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("column")]
  [Alias("Column")]
  public class Column
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue W{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue Space{ get; set; }

  }
}

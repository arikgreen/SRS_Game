using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Tag("twipsMeasure")]
  [Alias("TwipsMeasure")]
  public class TwipsMeasureType
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue Val{ get; set; }

  }
}

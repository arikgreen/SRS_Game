using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("height")]
  [Alias("Height")]
  public class TwipsMeasureType
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue Val{ get; set; }

    [Tag("heightRule")]
    HeightRuleValues HRule{ get; set; }

  }
}

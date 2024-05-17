using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("hpsMeasure")]
  [Alias("HpsMeasure")]
  public class HpsMeasureType
  {
    [Tag("hpsMeasure")]
    HpsMeasureValue Val{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("height")]
  [Alias("Height")]
  public class TwipsMeasure
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue Val{ get; set; }

    [Tag("heightRule")]
    HeightRuleValues HRule{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("object")]
  [Alias("Object")]
  public class EmbeddedObject
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue DxaOrig{ get; set; }

    [Tag("twipsMeasure")]
    TwipsMeasureValue DyaOrig{ get; set; }

  }
}

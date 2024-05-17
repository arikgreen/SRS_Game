using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("sDDescription")]
  [Alias("SDDescription")]
  public class EffectColorList
  {
    [Tag("string")]
    String Lang{ get; set; }

    [Tag("string")]
    String Val{ get; set; }

  }
}

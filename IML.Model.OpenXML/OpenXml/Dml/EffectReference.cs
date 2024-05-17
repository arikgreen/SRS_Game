using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("effectReference")]
  [Alias("EffectReference")]
  public class EffectReference
  {
    [Token]
    [Tag("token")]
    String Ref{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("effectContainer")]
  [Alias("EffectContainer")]
  public class EffectContainerType
  {
    [Tag("effectContainerType")]
    EffectContainerValues Type{ get; set; }

    [Token]
    [Tag("token")]
    String Name{ get; set; }

  }
}

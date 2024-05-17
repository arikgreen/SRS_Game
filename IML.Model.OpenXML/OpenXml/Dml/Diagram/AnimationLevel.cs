using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("animLvl")]
  [Alias("AnimLvl")]
  public class AnimationLevel
  {
    [Tag("animLvlStr")]
    AnimationLevelStringValues Val{ get; set; }

  }
}

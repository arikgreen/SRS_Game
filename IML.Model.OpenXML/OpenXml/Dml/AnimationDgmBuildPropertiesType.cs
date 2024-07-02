using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("animationDgmBuildProperties")]
  [Alias("AnimationDgmBuildProperties")]
  public class AnimationDgmBuildPropertiesType
  {
    [Tag("animationDgmBuildType")]
    AnimationDgmBuildTypeValue Bld{ get; set; }

    [Tag("boolean")]
    Boolean Rev{ get; set; }

  }
}

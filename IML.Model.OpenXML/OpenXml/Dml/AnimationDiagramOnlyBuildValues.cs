using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("AnimationDgmOnlyBuildType")]
  public enum AnimationDiagramOnlyBuildValues
  {
    [EnumString("one")]
    One = 0,
    [EnumString("lvlOne")]
    LvlOne,
    [EnumString("lvlAtOnce")]
    LvlAtOnce,
  }
}

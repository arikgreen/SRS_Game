using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("EffectContainerType")]
  public enum EffectContainerValues
  {
    [EnumString("sib")]
    Sib,
    [EnumString("tree")]
    Tree = 1,
  }
}

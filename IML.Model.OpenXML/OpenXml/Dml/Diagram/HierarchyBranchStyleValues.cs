using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("HierBranchStyle")]
  public enum HierarchyBranchStyleValues
  {
    [EnumString("l")]
    L,
    [EnumString("r")]
    R,
    [EnumString("hang")]
    Hang,
    [EnumString("std")]
    Std,
    [EnumString("init")]
    Init,
  }
}

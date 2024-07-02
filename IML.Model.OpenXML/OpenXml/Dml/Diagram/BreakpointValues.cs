using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("Breakpoint")]
  public enum BreakpointValues
  {
    [EnumString("endCnv")]
    EndCnv,
    [EnumString("bal")]
    Bal,
    [EnumString("fixed")]
    Fixed = 2,
  }
}

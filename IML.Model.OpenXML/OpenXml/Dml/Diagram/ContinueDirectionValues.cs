using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ContinueDirection")]
  public enum ContinueDirectionValues
  {
    [EnumString("revDir")]
    RevDir,
    [EnumString("sameDir")]
    SameDir,
  }
}

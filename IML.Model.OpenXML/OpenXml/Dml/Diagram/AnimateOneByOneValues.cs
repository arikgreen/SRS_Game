using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("AnimOneStr")]
  public enum AnimateOneByOneValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("one")]
    One = 1,
    [EnumString("branch")]
    Branch = 2,
  }
}

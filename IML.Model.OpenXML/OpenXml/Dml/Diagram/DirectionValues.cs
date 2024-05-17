using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("Direction")]
  public enum DirectionValues
  {
    [EnumString("norm")]
    Norm,
    [EnumString("rev")]
    Rev,
  }
}

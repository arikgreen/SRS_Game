using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("BoolOperator")]
  public enum BoolOperatorValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("equ")]
    Equ,
    [EnumString("gte")]
    Gte,
    [EnumString("lte")]
    Lte,
  }
}

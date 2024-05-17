using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("FunctionType")]
  public enum FunctionValues
  {
    [EnumString("cnt")]
    Cnt,
    [EnumString("pos")]
    Pos,
    [EnumString("revPos")]
    RevPos,
    [EnumString("posEven")]
    PosEven,
    [EnumString("posOdd")]
    PosOdd,
    [EnumString("var")]
    Var,
    [EnumString("depth")]
    Depth = 6,
    [EnumString("maxDepth")]
    MaxDepth = 7,
  }
}

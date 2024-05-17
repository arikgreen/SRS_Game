using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("FunctionOperator")]
  public enum FunctionOperatorValues
  {
    [EnumString("equ")]
    Equ,
    [EnumString("neq")]
    Neq,
    [EnumString("gt")]
    Gt,
    [EnumString("lt")]
    Lt,
    [EnumString("gte")]
    Gte,
    [EnumString("lte")]
    Lte,
  }
}

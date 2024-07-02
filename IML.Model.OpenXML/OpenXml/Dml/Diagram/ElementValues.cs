using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ElementType")]
  public enum ElementValues
  {
    [EnumString("all")]
    All = 0,
    [EnumString("doc")]
    Doc,
    [EnumString("node")]
    Node = 2,
    [EnumString("norm")]
    Norm,
    [EnumString("nonNorm")]
    NonNorm,
    [EnumString("asst")]
    Asst,
    [EnumString("nonAsst")]
    NonAsst,
    [EnumString("parTrans")]
    ParTrans,
    [EnumString("pres")]
    Pres,
    [EnumString("sibTrans")]
    SibTrans,
  }
}

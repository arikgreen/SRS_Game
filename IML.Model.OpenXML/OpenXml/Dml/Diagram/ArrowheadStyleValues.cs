using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ArrowheadStyle")]
  public enum ArrowheadStyleValues
  {
    [EnumString("auto")]
    Auto = 0,
    [EnumString("arr")]
    Arr,
    [EnumString("noArr")]
    NoArr,
  }
}

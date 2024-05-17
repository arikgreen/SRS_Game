using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("LimLoc")]
  public enum LimitLocationValues
  {
    [EnumString("undOvr")]
    UndOvr,
    [EnumString("subSup")]
    SubSup,
  }
}

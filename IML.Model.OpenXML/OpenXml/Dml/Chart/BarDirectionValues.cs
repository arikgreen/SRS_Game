using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("BarDir")]
  public enum BarDirectionValues
  {
    [EnumString("bar")]
    Bar = 0,
    [EnumString("col")]
    Col,
  }
}

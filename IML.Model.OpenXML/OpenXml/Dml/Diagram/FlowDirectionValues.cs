using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("FlowDirection")]
  public enum FlowDirectionValues
  {
    [EnumString("row")]
    Row = 0,
    [EnumString("col")]
    Col,
  }
}

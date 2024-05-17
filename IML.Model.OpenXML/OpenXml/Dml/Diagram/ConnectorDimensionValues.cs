using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ConnectorDimension")]
  public enum ConnectorDimensionValues
  {
    [EnumString("1D")]
    _1D,
    [EnumString("2D")]
    _2D,
    [EnumString("cust")]
    Cust,
  }
}

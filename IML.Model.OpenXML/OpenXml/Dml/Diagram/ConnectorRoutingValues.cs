using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("ConnectorRouting")]
  public enum ConnectorRoutingValues
  {
    [EnumString("stra")]
    Stra,
    [EnumString("bend")]
    Bend,
    [EnumString("curve")]
    Curve = 2,
    [EnumString("longCurve")]
    LongCurve = 3,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("OutputShapeType")]
  public enum OutputShapeValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("conn")]
    Conn,
  }
}

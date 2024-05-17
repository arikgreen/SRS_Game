using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("StartingElement")]
  public enum StartingElementValues
  {
    [EnumString("node")]
    Node = 0,
    [EnumString("trans")]
    Trans,
  }
}

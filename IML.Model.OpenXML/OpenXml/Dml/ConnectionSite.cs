using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("connectionSite")]
  [Alias("ConnectionSite")]
  public class ConnectionSite
  {
    [Tag("adjAngle")]
    AdjAngleValue Ang{ get; set; }

  }
}

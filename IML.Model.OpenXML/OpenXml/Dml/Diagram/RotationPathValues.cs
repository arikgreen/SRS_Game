using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Alias("RotationPath")]
  public enum RotationPathValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("alongPath")]
    AlongPath = 1,
  }
}

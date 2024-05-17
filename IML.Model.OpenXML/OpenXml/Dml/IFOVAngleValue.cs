using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [MaxValue(10800000)]
  [Alias("FOVAngle")]
  public interface IFOVAngleValue
  {
    Int32 AsInt32{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [MaxValue(21599999)]
  [Alias("PositiveFixedAngle")]
  public interface IPositiveFixedAngleValue
  {
    Int32 AsInt32{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(-5399999)]
  [MaxValue(5399999)]
  [Alias("FixedAngle")]
  public interface IFixedAngleValue
  {
    Int32 AsInt32{ get; set; }

  }
}

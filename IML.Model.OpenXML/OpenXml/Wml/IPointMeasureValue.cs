using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PointMeasure")]
  public interface IPointMeasureValue
  {
    UInt64 AsUInt64{ get; set; }

  }
}

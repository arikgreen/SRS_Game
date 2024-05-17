using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PixelsMeasure")]
  public interface IPixelsMeasureValue
  {
    UInt64 AsUInt64{ get; set; }

  }
}

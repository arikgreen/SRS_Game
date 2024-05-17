using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [MaxValue(20116800)]
  [Alias("LineWidth")]
  public interface ILineWidthValue
  {
    Int32 AsInt32{ get; set; }

  }
}

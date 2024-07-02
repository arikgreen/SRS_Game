using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("AxisUnit")]
  public interface IAxisUnitValue
  {
    Double AsDouble{ get; set; }

  }
}

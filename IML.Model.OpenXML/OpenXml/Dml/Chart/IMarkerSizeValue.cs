using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("MarkerSize")]
  public interface IMarkerSizeValue
  {
    Byte AsByte{ get; set; }

  }
}

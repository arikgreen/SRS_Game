using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("DrawingElementId")]
  public interface IDrawingElementIdValue
  {
    UInt32 AsUInt32{ get; set; }

  }
}

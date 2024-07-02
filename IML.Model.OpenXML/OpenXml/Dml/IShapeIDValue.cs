using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Token]
  [Alias("ShapeID")]
  public interface IShapeIDValue
  {
    String AsString{ get; set; }

  }
}

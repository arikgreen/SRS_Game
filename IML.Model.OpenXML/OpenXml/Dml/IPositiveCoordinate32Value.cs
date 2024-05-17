using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [MinValue(0)]
  [Alias("PositiveCoordinate32")]
  public interface IPositiveCoordinate32Value
  {
    Int32 AsInt32{ get; set; }

  }
}

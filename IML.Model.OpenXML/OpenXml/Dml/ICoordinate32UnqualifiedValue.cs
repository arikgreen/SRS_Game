using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("Coordinate32Unqualified")]
  public interface ICoordinate32UnqualifiedValue
  {
    Int32 AsInt32{ get; set; }

  }
}

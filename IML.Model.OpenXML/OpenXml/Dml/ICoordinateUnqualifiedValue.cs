using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("CoordinateUnqualified")]
  public interface ICoordinateUnqualifiedValue
  {
    Int64 AsInt64{ get; set; }

  }
}

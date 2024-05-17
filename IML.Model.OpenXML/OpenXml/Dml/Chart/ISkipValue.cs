using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("Skip")]
  public interface ISkipValue
  {
    UInt32 AsUInt32{ get; set; }

  }
}

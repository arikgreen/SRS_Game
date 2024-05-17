using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Alias("WrapDistance")]
  public interface IWrapDistanceValue
  {
    UInt32 AsUInt32{ get; set; }

  }
}

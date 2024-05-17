using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Math
{
  [Alias("UnSignedInteger")]
  public interface IUnSignedIntegerValue
  {
    UInt32 AsUInt32{ get; set; }

  }
}

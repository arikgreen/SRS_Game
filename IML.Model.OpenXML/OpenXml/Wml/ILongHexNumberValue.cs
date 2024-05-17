using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Format("X8")]
  [Alias("LongHexNumber")]
  public interface ILongHexNumberValue
  {
    UInt32 AsUInt32{ get; set; }

  }
}

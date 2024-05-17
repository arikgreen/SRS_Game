using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Format("X4")]
  [Alias("ShortHexNumber")]
  public interface IShortHexNumberValue
  {
    UInt16 AsUInt16{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("ErrDir")]
  public enum ErrorBarDirectionValues
  {
    [EnumString("x")]
    X = 0,
    [EnumString("y")]
    Y = 1,
  }
}

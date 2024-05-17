using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("ErrBarType")]
  public enum ErrorBarValues
  {
    [EnumString("both")]
    Both = 0,
    [EnumString("minus")]
    Minus = 1,
    [EnumString("plus")]
    Plus = 2,
  }
}

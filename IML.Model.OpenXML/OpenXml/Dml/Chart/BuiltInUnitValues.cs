using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("BuiltInUnit")]
  public enum BuiltInUnitValues
  {
    [EnumString("hundreds")]
    Hundreds = 0,
    [EnumString("thousands")]
    Thousands = 1,
    [EnumString("tenThousands")]
    TenThousands = 2,
    [EnumString("hundredThousands")]
    HundredThousands = 3,
    [EnumString("millions")]
    Millions = 4,
    [EnumString("tenMillions")]
    TenMillions = 5,
    [EnumString("hundredMillions")]
    HundredMillions = 6,
    [EnumString("billions")]
    Billions = 7,
    [EnumString("trillions")]
    Trillions = 8,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Alias("WrapText")]
  public enum WrapTextValues
  {
    [EnumString("bothSides")]
    BothSides = 0,
    [EnumString("left")]
    Left = 1,
    [EnumString("right")]
    Right = 2,
    [EnumString("largest")]
    Largest = 3,
  }
}

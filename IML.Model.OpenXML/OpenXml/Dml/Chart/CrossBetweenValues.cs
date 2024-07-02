using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("CrossBetween")]
  public enum CrossBetweenValues
  {
    [EnumString("between")]
    Between = 0,
    [EnumString("midCat")]
    MidCat,
  }
}

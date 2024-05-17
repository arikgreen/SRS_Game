using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("DispBlanksAs")]
  public enum DisplayBlanksAsValues
  {
    [EnumString("span")]
    Span = 0,
    [EnumString("gap")]
    Gap = 1,
    [EnumString("zero")]
    Zero = 2,
  }
}

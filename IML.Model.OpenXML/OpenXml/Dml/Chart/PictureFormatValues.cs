using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("PictureFormat")]
  public enum PictureFormatValues
  {
    [EnumString("stretch")]
    Stretch = 0,
    [EnumString("stack")]
    Stack = 1,
    [EnumString("stackScale")]
    StackScale = 2,
  }
}

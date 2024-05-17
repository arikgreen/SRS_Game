using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("PageBorderZOrder")]
  public enum PageBorderZOrderValues
  {
    [EnumString("front")]
    Front = 0,
    [EnumString("back")]
    Back = 1,
  }
}

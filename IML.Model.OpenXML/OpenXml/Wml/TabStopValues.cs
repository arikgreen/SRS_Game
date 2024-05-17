using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("JcTable")]
  public enum TabStopValues
  {
    [EnumString("center")]
    Center = 3,
    [EnumString("end")]
    End = 5,
    [EnumString("start")]
    Start = 2,
  }
}

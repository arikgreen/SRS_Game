using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DocPartBehavior")]
  public enum DocPartBehaviorValues
  {
    [EnumString("content")]
    Content = 0,
    [EnumString("p")]
    P,
    [EnumString("pg")]
    Pg,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("LineCap")]
  public enum LineCapValues
  {
    [EnumString("rnd")]
    Rnd,
    [EnumString("sq")]
    Sq,
    [EnumString("flat")]
    Flat = 2,
  }
}

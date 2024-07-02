using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("BlendMode")]
  public enum BlendModeValues
  {
    [EnumString("over")]
    Over,
    [EnumString("mult")]
    Mult,
    [EnumString("screen")]
    Screen = 2,
    [EnumString("darken")]
    Darken = 3,
    [EnumString("lighten")]
    Lighten = 4,
  }
}

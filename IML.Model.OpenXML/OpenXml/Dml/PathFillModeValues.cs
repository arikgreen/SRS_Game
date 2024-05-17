using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PathFillMode")]
  public enum PathFillModeValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("norm")]
    Norm = 1,
    [EnumString("lighten")]
    Lighten = 2,
    [EnumString("lightenLess")]
    LightenLess = 3,
    [EnumString("darken")]
    Darken = 4,
    [EnumString("darkenLess")]
    DarkenLess = 5,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TileFlipMode")]
  public enum TileFlipValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("x")]
    X,
    [EnumString("y")]
    Y,
    [EnumString("xy")]
    Xy,
  }
}

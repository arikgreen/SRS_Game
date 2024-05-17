using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Alias("MarkerStyle")]
  public enum MarkerStyleValues
  {
    [EnumString("circle")]
    Circle = 1,
    [EnumString("dash")]
    Dash = 2,
    [EnumString("diamond")]
    Diamond = 3,
    [EnumString("dot")]
    Dot = 4,
    [EnumString("none")]
    None = 5,
    [EnumString("picture")]
    Picture = 6,
    [EnumString("plus")]
    Plus = 7,
    [EnumString("square")]
    Square = 8,
    [EnumString("star")]
    Star = 9,
    [EnumString("triangle")]
    Triangle = 10,
    [EnumString("x")]
    X = 11,
    [EnumString("auto")]
    Auto = 0,
  }
}

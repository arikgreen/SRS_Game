using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("HighlightColor")]
  public enum HighlightColorValues
  {
    [EnumString("black")]
    Black = 0,
    [EnumString("blue")]
    Blue = 1,
    [EnumString("cyan")]
    Cyan = 2,
    [EnumString("green")]
    Green = 3,
    [EnumString("magenta")]
    Magenta = 4,
    [EnumString("red")]
    Red = 5,
    [EnumString("yellow")]
    Yellow = 6,
    [EnumString("white")]
    White = 7,
    [EnumString("darkBlue")]
    DarkBlue = 8,
    [EnumString("darkCyan")]
    DarkCyan = 9,
    [EnumString("darkGreen")]
    DarkGreen = 10,
    [EnumString("darkMagenta")]
    DarkMagenta = 11,
    [EnumString("darkRed")]
    DarkRed = 12,
    [EnumString("darkYellow")]
    DarkYellow = 13,
    [EnumString("darkGray")]
    DarkGray = 14,
    [EnumString("lightGray")]
    LightGray = 15,
    [EnumString("none")]
    None = 16,
  }
}

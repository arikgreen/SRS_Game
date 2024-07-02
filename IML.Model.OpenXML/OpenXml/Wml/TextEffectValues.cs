using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("TextEffect")]
  public enum TextEffectValues
  {
    [EnumString("blinkBackground")]
    BlinkBackground = 0,
    [EnumString("lights")]
    Lights = 1,
    [EnumString("antsBlack")]
    AntsBlack = 2,
    [EnumString("antsRed")]
    AntsRed = 3,
    [EnumString("shimmer")]
    Shimmer = 4,
    [EnumString("sparkle")]
    Sparkle = 5,
    [EnumString("none")]
    None = 6,
  }
}

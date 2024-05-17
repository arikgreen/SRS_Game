using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("ThemeColor")]
  public enum ThemeColorValues
  {
    [EnumString("dark1")]
    Dark1 = 0,
    [EnumString("light1")]
    Light1 = 1,
    [EnumString("dark2")]
    Dark2 = 2,
    [EnumString("light2")]
    Light2 = 3,
    [EnumString("accent1")]
    Accent1 = 4,
    [EnumString("accent2")]
    Accent2 = 5,
    [EnumString("accent3")]
    Accent3 = 6,
    [EnumString("accent4")]
    Accent4 = 7,
    [EnumString("accent5")]
    Accent5 = 8,
    [EnumString("accent6")]
    Accent6 = 9,
    [EnumString("hyperlink")]
    Hyperlink = 10,
    [EnumString("followedHyperlink")]
    FollowedHyperlink = 11,
    [EnumString("none")]
    None = 12,
    [EnumString("background1")]
    Background1 = 13,
    [EnumString("text1")]
    Text1 = 14,
    [EnumString("background2")]
    Background2 = 15,
    [EnumString("text2")]
    Text2 = 16,
  }
}

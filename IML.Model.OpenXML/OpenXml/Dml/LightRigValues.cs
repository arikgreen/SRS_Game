using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("LightRigType")]
  public enum LightRigValues
  {
    [EnumString("legacyFlat1")]
    LegacyFlat1 = 0,
    [EnumString("legacyFlat2")]
    LegacyFlat2 = 1,
    [EnumString("legacyFlat3")]
    LegacyFlat3 = 2,
    [EnumString("legacyFlat4")]
    LegacyFlat4 = 3,
    [EnumString("legacyNormal1")]
    LegacyNormal1 = 4,
    [EnumString("legacyNormal2")]
    LegacyNormal2 = 5,
    [EnumString("legacyNormal3")]
    LegacyNormal3 = 6,
    [EnumString("legacyNormal4")]
    LegacyNormal4 = 7,
    [EnumString("legacyHarsh1")]
    LegacyHarsh1 = 8,
    [EnumString("legacyHarsh2")]
    LegacyHarsh2 = 9,
    [EnumString("legacyHarsh3")]
    LegacyHarsh3 = 10,
    [EnumString("legacyHarsh4")]
    LegacyHarsh4 = 11,
    [EnumString("threePt")]
    ThreePt,
    [EnumString("balanced")]
    Balanced = 13,
    [EnumString("soft")]
    Soft = 14,
    [EnumString("harsh")]
    Harsh = 15,
    [EnumString("flood")]
    Flood = 16,
    [EnumString("contrasting")]
    Contrasting = 17,
    [EnumString("morning")]
    Morning = 18,
    [EnumString("sunrise")]
    Sunrise = 19,
    [EnumString("sunset")]
    Sunset = 20,
    [EnumString("chilly")]
    Chilly = 21,
    [EnumString("freezing")]
    Freezing = 22,
    [EnumString("flat")]
    Flat = 23,
    [EnumString("twoPt")]
    TwoPt,
    [EnumString("glow")]
    Glow = 25,
    [EnumString("brightRoom")]
    BrightRoom = 26,
  }
}

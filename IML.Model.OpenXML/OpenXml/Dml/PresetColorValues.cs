using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("PresetColorVal")]
  public enum PresetColorValues
  {
    [EnumString("aliceBlue")]
    AliceBlue = 0,
    [EnumString("antiqueWhite")]
    AntiqueWhite = 1,
    [EnumString("aqua")]
    Aqua = 2,
    [EnumString("aquamarine")]
    Aquamarine = 3,
    [EnumString("azure")]
    Azure = 4,
    [EnumString("beige")]
    Beige = 5,
    [EnumString("bisque")]
    Bisque = 6,
    [EnumString("black")]
    Black = 7,
    [EnumString("blanchedAlmond")]
    BlanchedAlmond = 8,
    [EnumString("blue")]
    Blue = 9,
    [EnumString("blueViolet")]
    BlueViolet = 10,
    [EnumString("brown")]
    Brown = 11,
    [EnumString("burlyWood")]
    BurlyWood = 12,
    [EnumString("cadetBlue")]
    CadetBlue = 13,
    [EnumString("chartreuse")]
    Chartreuse = 14,
    [EnumString("chocolate")]
    Chocolate = 15,
    [EnumString("coral")]
    Coral = 16,
    [EnumString("cornflowerBlue")]
    CornflowerBlue = 17,
    [EnumString("cornsilk")]
    Cornsilk = 18,
    [EnumString("crimson")]
    Crimson = 19,
    [EnumString("cyan")]
    Cyan = 20,
    [EnumString("darkBlue")]
    DarkBlue = 21,
    [EnumString("darkCyan")]
    DarkCyan = 22,
    [EnumString("darkGoldenrod")]
    DarkGoldenrod = 23,
    [EnumString("darkGray")]
    DarkGray = 24,
    [EnumString("darkGrey")]
    DarkGrey = 183,
    [EnumString("darkGreen")]
    DarkGreen = 25,
    [EnumString("darkKhaki")]
    DarkKhaki = 26,
    [EnumString("darkMagenta")]
    DarkMagenta = 27,
    [EnumString("darkOliveGreen")]
    DarkOliveGreen = 28,
    [EnumString("darkOrange")]
    DarkOrange = 29,
    [EnumString("darkOrchid")]
    DarkOrchid = 30,
    [EnumString("darkRed")]
    DarkRed = 31,
    [EnumString("darkSalmon")]
    DarkSalmon = 32,
    [EnumString("darkSeaGreen")]
    DarkSeaGreen = 33,
    [EnumString("darkSlateBlue")]
    DarkSlateBlue = 34,
    [EnumString("darkSlateGray")]
    DarkSlateGray = 35,
    [EnumString("darkSlateGrey")]
    DarkSlateGrey = 185,
    [EnumString("darkTurquoise")]
    DarkTurquoise = 36,
    [EnumString("darkViolet")]
    DarkViolet = 37,
    [EnumString("dkBlue")]
    DkBlue,
    [EnumString("dkCyan")]
    DkCyan,
    [EnumString("dkGoldenrod")]
    DkGoldenrod,
    [EnumString("dkGray")]
    DkGray,
    [EnumString("dkGrey")]
    DkGrey,
    [EnumString("dkGreen")]
    DkGreen,
    [EnumString("dkKhaki")]
    DkKhaki,
    [EnumString("dkMagenta")]
    DkMagenta,
    [EnumString("dkOliveGreen")]
    DkOliveGreen,
    [EnumString("dkOrange")]
    DkOrange,
    [EnumString("dkOrchid")]
    DkOrchid,
    [EnumString("dkRed")]
    DkRed,
    [EnumString("dkSalmon")]
    DkSalmon,
    [EnumString("dkSeaGreen")]
    DkSeaGreen,
    [EnumString("dkSlateBlue")]
    DkSlateBlue,
    [EnumString("dkSlateGray")]
    DkSlateGray,
    [EnumString("dkSlateGrey")]
    DkSlateGrey,
    [EnumString("dkTurquoise")]
    DkTurquoise,
    [EnumString("dkViolet")]
    DkViolet,
    [EnumString("deepPink")]
    DeepPink = 38,
    [EnumString("deepSkyBlue")]
    DeepSkyBlue = 39,
    [EnumString("dimGray")]
    DimGray = 40,
    [EnumString("dimGrey")]
    DimGrey = 184,
    [EnumString("dodgerBlue")]
    DodgerBlue = 41,
    [EnumString("firebrick")]
    Firebrick = 42,
    [EnumString("floralWhite")]
    FloralWhite = 43,
    [EnumString("forestGreen")]
    ForestGreen = 44,
    [EnumString("fuchsia")]
    Fuchsia = 45,
    [EnumString("gainsboro")]
    Gainsboro = 46,
    [EnumString("ghostWhite")]
    GhostWhite = 47,
    [EnumString("gold")]
    Gold = 48,
    [EnumString("goldenrod")]
    Goldenrod = 49,
    [EnumString("gray")]
    Gray = 50,
    [EnumString("grey")]
    Grey = 186,
    [EnumString("green")]
    Green = 51,
    [EnumString("greenYellow")]
    GreenYellow = 52,
    [EnumString("honeydew")]
    Honeydew = 53,
    [EnumString("hotPink")]
    HotPink = 54,
    [EnumString("indianRed")]
    IndianRed = 55,
    [EnumString("indigo")]
    Indigo = 56,
    [EnumString("ivory")]
    Ivory = 57,
    [EnumString("khaki")]
    Khaki = 58,
    [EnumString("lavender")]
    Lavender = 59,
    [EnumString("lavenderBlush")]
    LavenderBlush = 60,
    [EnumString("lawnGreen")]
    LawnGreen = 61,
    [EnumString("lemonChiffon")]
    LemonChiffon = 62,
    [EnumString("lightBlue")]
    LightBlue = 63,
    [EnumString("lightCoral")]
    LightCoral = 64,
    [EnumString("lightCyan")]
    LightCyan = 65,
    [EnumString("lightGoldenrodYellow")]
    LightGoldenrodYellow = 66,
    [EnumString("lightGray")]
    LightGray = 67,
    [EnumString("lightGrey")]
    LightGrey = 187,
    [EnumString("lightGreen")]
    LightGreen = 68,
    [EnumString("lightPink")]
    LightPink = 69,
    [EnumString("lightSalmon")]
    LightSalmon = 70,
    [EnumString("lightSeaGreen")]
    LightSeaGreen = 71,
    [EnumString("lightSkyBlue")]
    LightSkyBlue = 72,
    [EnumString("lightSlateGray")]
    LightSlateGray = 73,
    [EnumString("lightSlateGrey")]
    LightSlateGrey = 188,
    [EnumString("lightSteelBlue")]
    LightSteelBlue = 74,
    [EnumString("lightYellow")]
    LightYellow = 75,
    [EnumString("ltBlue")]
    LtBlue,
    [EnumString("ltCoral")]
    LtCoral,
    [EnumString("ltCyan")]
    LtCyan,
    [EnumString("ltGoldenrodYellow")]
    LtGoldenrodYellow,
    [EnumString("ltGray")]
    LtGray,
    [EnumString("ltGrey")]
    LtGrey,
    [EnumString("ltGreen")]
    LtGreen,
    [EnumString("ltPink")]
    LtPink,
    [EnumString("ltSalmon")]
    LtSalmon,
    [EnumString("ltSeaGreen")]
    LtSeaGreen,
    [EnumString("ltSkyBlue")]
    LtSkyBlue,
    [EnumString("ltSlateGray")]
    LtSlateGray,
    [EnumString("ltSlateGrey")]
    LtSlateGrey,
    [EnumString("ltSteelBlue")]
    LtSteelBlue,
    [EnumString("ltYellow")]
    LtYellow,
    [EnumString("lime")]
    Lime = 76,
    [EnumString("limeGreen")]
    LimeGreen = 77,
    [EnumString("linen")]
    Linen = 78,
    [EnumString("magenta")]
    Magenta = 79,
    [EnumString("maroon")]
    Maroon = 80,
    [EnumString("medAquamarine")]
    MedAquamarine = 81,
    [EnumString("medBlue")]
    MedBlue,
    [EnumString("medOrchid")]
    MedOrchid,
    [EnumString("medPurple")]
    MedPurple,
    [EnumString("medSeaGreen")]
    MedSeaGreen,
    [EnumString("medSlateBlue")]
    MedSlateBlue,
    [EnumString("medSpringGreen")]
    MedSpringGreen,
    [EnumString("medTurquoise")]
    MedTurquoise,
    [EnumString("medVioletRed")]
    MedVioletRed,
    [EnumString("mediumAquamarine")]
    MediumAquamarine,
    [EnumString("mediumBlue")]
    MediumBlue = 82,
    [EnumString("mediumOrchid")]
    MediumOrchid = 83,
    [EnumString("mediumPurple")]
    MediumPurple = 84,
    [EnumString("mediumSeaGreen")]
    MediumSeaGreen = 85,
    [EnumString("mediumSlateBlue")]
    MediumSlateBlue = 86,
    [EnumString("mediumSpringGreen")]
    MediumSpringGreen = 87,
    [EnumString("mediumTurquoise")]
    MediumTurquoise = 88,
    [EnumString("mediumVioletRed")]
    MediumVioletRed = 89,
    [EnumString("midnightBlue")]
    MidnightBlue = 90,
    [EnumString("mintCream")]
    MintCream = 91,
    [EnumString("mistyRose")]
    MistyRose = 92,
    [EnumString("moccasin")]
    Moccasin = 93,
    [EnumString("navajoWhite")]
    NavajoWhite = 94,
    [EnumString("navy")]
    Navy = 95,
    [EnumString("oldLace")]
    OldLace = 96,
    [EnumString("olive")]
    Olive = 97,
    [EnumString("oliveDrab")]
    OliveDrab = 98,
    [EnumString("orange")]
    Orange = 99,
    [EnumString("orangeRed")]
    OrangeRed = 100,
    [EnumString("orchid")]
    Orchid = 101,
    [EnumString("paleGoldenrod")]
    PaleGoldenrod = 102,
    [EnumString("paleGreen")]
    PaleGreen = 103,
    [EnumString("paleTurquoise")]
    PaleTurquoise = 104,
    [EnumString("paleVioletRed")]
    PaleVioletRed = 105,
    [EnumString("papayaWhip")]
    PapayaWhip = 106,
    [EnumString("peachPuff")]
    PeachPuff = 107,
    [EnumString("peru")]
    Peru = 108,
    [EnumString("pink")]
    Pink = 109,
    [EnumString("plum")]
    Plum = 110,
    [EnumString("powderBlue")]
    PowderBlue = 111,
    [EnumString("purple")]
    Purple = 112,
    [EnumString("red")]
    Red = 113,
    [EnumString("rosyBrown")]
    RosyBrown = 114,
    [EnumString("royalBlue")]
    RoyalBlue = 115,
    [EnumString("saddleBrown")]
    SaddleBrown = 116,
    [EnumString("salmon")]
    Salmon = 117,
    [EnumString("sandyBrown")]
    SandyBrown = 118,
    [EnumString("seaGreen")]
    SeaGreen = 119,
    [EnumString("seaShell")]
    SeaShell = 120,
    [EnumString("sienna")]
    Sienna = 121,
    [EnumString("silver")]
    Silver = 122,
    [EnumString("skyBlue")]
    SkyBlue = 123,
    [EnumString("slateBlue")]
    SlateBlue = 124,
    [EnumString("slateGray")]
    SlateGray = 125,
    [EnumString("slateGrey")]
    SlateGrey = 189,
    [EnumString("snow")]
    Snow = 126,
    [EnumString("springGreen")]
    SpringGreen = 127,
    [EnumString("steelBlue")]
    SteelBlue = 128,
    [EnumString("tan")]
    Tan = 129,
    [EnumString("teal")]
    Teal = 130,
    [EnumString("thistle")]
    Thistle = 131,
    [EnumString("tomato")]
    Tomato = 132,
    [EnumString("turquoise")]
    Turquoise = 133,
    [EnumString("violet")]
    Violet = 134,
    [EnumString("wheat")]
    Wheat = 135,
    [EnumString("white")]
    White = 136,
    [EnumString("whiteSmoke")]
    WhiteSmoke = 137,
    [EnumString("yellow")]
    Yellow = 138,
    [EnumString("yellowGreen")]
    YellowGreen = 139,
  }
}

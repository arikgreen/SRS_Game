using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("Border")]
  public enum BorderValues
  {
    [EnumString("nil")]
    Nil = 0,
    [EnumString("none")]
    None = 1,
    [EnumString("single")]
    Single = 2,
    [EnumString("thick")]
    Thick = 3,
    [EnumString("double")]
    Double = 4,
    [EnumString("dotted")]
    Dotted = 5,
    [EnumString("dashed")]
    Dashed = 6,
    [EnumString("dotDash")]
    DotDash = 7,
    [EnumString("dotDotDash")]
    DotDotDash = 8,
    [EnumString("triple")]
    Triple = 9,
    [EnumString("thinThickSmallGap")]
    ThinThickSmallGap = 10,
    [EnumString("thickThinSmallGap")]
    ThickThinSmallGap = 11,
    [EnumString("thinThickThinSmallGap")]
    ThinThickThinSmallGap = 12,
    [EnumString("thinThickMediumGap")]
    ThinThickMediumGap = 13,
    [EnumString("thickThinMediumGap")]
    ThickThinMediumGap = 14,
    [EnumString("thinThickThinMediumGap")]
    ThinThickThinMediumGap = 15,
    [EnumString("thinThickLargeGap")]
    ThinThickLargeGap = 16,
    [EnumString("thickThinLargeGap")]
    ThickThinLargeGap = 17,
    [EnumString("thinThickThinLargeGap")]
    ThinThickThinLargeGap = 18,
    [EnumString("wave")]
    Wave = 19,
    [EnumString("doubleWave")]
    DoubleWave = 20,
    [EnumString("dashSmallGap")]
    DashSmallGap = 21,
    [EnumString("dashDotStroked")]
    DashDotStroked = 22,
    [EnumString("threeDEmboss")]
    ThreeDEmboss = 23,
    [EnumString("threeDEngrave")]
    ThreeDEngrave = 24,
    [EnumString("outset")]
    Outset = 25,
    [EnumString("inset")]
    Inset = 26,
    [EnumString("apples")]
    Apples = 27,
    [EnumString("archedScallops")]
    ArchedScallops = 28,
    [EnumString("babyPacifier")]
    BabyPacifier = 29,
    [EnumString("babyRattle")]
    BabyRattle = 30,
    [EnumString("balloons3Colors")]
    Balloons3Colors = 31,
    [EnumString("balloonsHotAir")]
    BalloonsHotAir = 32,
    [EnumString("basicBlackDashes")]
    BasicBlackDashes = 33,
    [EnumString("basicBlackDots")]
    BasicBlackDots = 34,
    [EnumString("basicBlackSquares")]
    BasicBlackSquares = 35,
    [EnumString("basicThinLines")]
    BasicThinLines = 36,
    [EnumString("basicWhiteDashes")]
    BasicWhiteDashes = 37,
    [EnumString("basicWhiteDots")]
    BasicWhiteDots = 38,
    [EnumString("basicWhiteSquares")]
    BasicWhiteSquares = 39,
    [EnumString("basicWideInline")]
    BasicWideInline = 40,
    [EnumString("basicWideMidline")]
    BasicWideMidline = 41,
    [EnumString("basicWideOutline")]
    BasicWideOutline = 42,
    [EnumString("bats")]
    Bats = 43,
    [EnumString("birds")]
    Birds = 44,
    [EnumString("birdsFlight")]
    BirdsFlight = 45,
    [EnumString("cabins")]
    Cabins = 46,
    [EnumString("cakeSlice")]
    CakeSlice = 47,
    [EnumString("candyCorn")]
    CandyCorn = 48,
    [EnumString("celticKnotwork")]
    CelticKnotwork = 49,
    [EnumString("certificateBanner")]
    CertificateBanner = 50,
    [EnumString("chainLink")]
    ChainLink = 51,
    [EnumString("champagneBottle")]
    ChampagneBottle = 52,
    [EnumString("checkedBarBlack")]
    CheckedBarBlack = 53,
    [EnumString("checkedBarColor")]
    CheckedBarColor = 54,
    [EnumString("checkered")]
    Checkered = 55,
    [EnumString("christmasTree")]
    ChristmasTree = 56,
    [EnumString("circlesLines")]
    CirclesLines = 57,
    [EnumString("circlesRectangles")]
    CirclesRectangles = 58,
    [EnumString("classicalWave")]
    ClassicalWave = 59,
    [EnumString("clocks")]
    Clocks = 60,
    [EnumString("compass")]
    Compass = 61,
    [EnumString("confetti")]
    Confetti = 62,
    [EnumString("confettiGrays")]
    ConfettiGrays = 63,
    [EnumString("confettiOutline")]
    ConfettiOutline = 64,
    [EnumString("confettiStreamers")]
    ConfettiStreamers = 65,
    [EnumString("confettiWhite")]
    ConfettiWhite = 66,
    [EnumString("cornerTriangles")]
    CornerTriangles = 67,
    [EnumString("couponCutoutDashes")]
    CouponCutoutDashes = 68,
    [EnumString("couponCutoutDots")]
    CouponCutoutDots = 69,
    [EnumString("crazyMaze")]
    CrazyMaze = 70,
    [EnumString("creaturesButterfly")]
    CreaturesButterfly = 71,
    [EnumString("creaturesFish")]
    CreaturesFish = 72,
    [EnumString("creaturesInsects")]
    CreaturesInsects = 73,
    [EnumString("creaturesLadyBug")]
    CreaturesLadyBug = 74,
    [EnumString("crossStitch")]
    CrossStitch = 75,
    [EnumString("cup")]
    Cup = 76,
    [EnumString("decoArch")]
    DecoArch = 77,
    [EnumString("decoArchColor")]
    DecoArchColor = 78,
    [EnumString("decoBlocks")]
    DecoBlocks = 79,
    [EnumString("diamondsGray")]
    DiamondsGray = 80,
    [EnumString("doubleD")]
    DoubleD = 81,
    [EnumString("doubleDiamonds")]
    DoubleDiamonds = 82,
    [EnumString("earth1")]
    Earth1 = 83,
    [EnumString("earth2")]
    Earth2 = 84,
    [EnumString("earth3")]
    Earth3,
    [EnumString("eclipsingSquares1")]
    EclipsingSquares1 = 85,
    [EnumString("eclipsingSquares2")]
    EclipsingSquares2 = 86,
    [EnumString("eggsBlack")]
    EggsBlack = 87,
    [EnumString("fans")]
    Fans = 88,
    [EnumString("film")]
    Film = 89,
    [EnumString("firecrackers")]
    Firecrackers = 90,
    [EnumString("flowersBlockPrint")]
    FlowersBlockPrint = 91,
    [EnumString("flowersDaisies")]
    FlowersDaisies = 92,
    [EnumString("flowersModern1")]
    FlowersModern1 = 93,
    [EnumString("flowersModern2")]
    FlowersModern2 = 94,
    [EnumString("flowersPansy")]
    FlowersPansy = 95,
    [EnumString("flowersRedRose")]
    FlowersRedRose = 96,
    [EnumString("flowersRoses")]
    FlowersRoses = 97,
    [EnumString("flowersTeacup")]
    FlowersTeacup = 98,
    [EnumString("flowersTiny")]
    FlowersTiny = 99,
    [EnumString("gems")]
    Gems = 100,
    [EnumString("gingerbreadMan")]
    GingerbreadMan = 101,
    [EnumString("gradient")]
    Gradient = 102,
    [EnumString("handmade1")]
    Handmade1 = 103,
    [EnumString("handmade2")]
    Handmade2 = 104,
    [EnumString("heartBalloon")]
    HeartBalloon = 105,
    [EnumString("heartGray")]
    HeartGray = 106,
    [EnumString("hearts")]
    Hearts = 107,
    [EnumString("heebieJeebies")]
    HeebieJeebies = 108,
    [EnumString("holly")]
    Holly = 109,
    [EnumString("houseFunky")]
    HouseFunky = 110,
    [EnumString("hypnotic")]
    Hypnotic = 111,
    [EnumString("iceCreamCones")]
    IceCreamCones = 112,
    [EnumString("lightBulb")]
    LightBulb = 113,
    [EnumString("lightning1")]
    Lightning1 = 114,
    [EnumString("lightning2")]
    Lightning2 = 115,
    [EnumString("mapPins")]
    MapPins = 116,
    [EnumString("mapleLeaf")]
    MapleLeaf = 117,
    [EnumString("mapleMuffins")]
    MapleMuffins = 118,
    [EnumString("marquee")]
    Marquee = 119,
    [EnumString("marqueeToothed")]
    MarqueeToothed = 120,
    [EnumString("moons")]
    Moons = 121,
    [EnumString("mosaic")]
    Mosaic = 122,
    [EnumString("musicNotes")]
    MusicNotes = 123,
    [EnumString("northwest")]
    Northwest = 124,
    [EnumString("ovals")]
    Ovals = 125,
    [EnumString("packages")]
    Packages = 126,
    [EnumString("palmsBlack")]
    PalmsBlack = 127,
    [EnumString("palmsColor")]
    PalmsColor = 128,
    [EnumString("paperClips")]
    PaperClips = 129,
    [EnumString("papyrus")]
    Papyrus = 130,
    [EnumString("partyFavor")]
    PartyFavor = 131,
    [EnumString("partyGlass")]
    PartyGlass = 132,
    [EnumString("pencils")]
    Pencils = 133,
    [EnumString("people")]
    People = 134,
    [EnumString("peopleWaving")]
    PeopleWaving = 135,
    [EnumString("peopleHats")]
    PeopleHats = 136,
    [EnumString("poinsettias")]
    Poinsettias = 137,
    [EnumString("postageStamp")]
    PostageStamp = 138,
    [EnumString("pumpkin1")]
    Pumpkin1 = 139,
    [EnumString("pushPinNote2")]
    PushPinNote2 = 140,
    [EnumString("pushPinNote1")]
    PushPinNote1 = 141,
    [EnumString("pyramids")]
    Pyramids = 142,
    [EnumString("pyramidsAbove")]
    PyramidsAbove = 143,
    [EnumString("quadrants")]
    Quadrants = 144,
    [EnumString("rings")]
    Rings = 145,
    [EnumString("safari")]
    Safari = 146,
    [EnumString("sawtooth")]
    Sawtooth = 147,
    [EnumString("sawtoothGray")]
    SawtoothGray = 148,
    [EnumString("scaredCat")]
    ScaredCat = 149,
    [EnumString("seattle")]
    Seattle = 150,
    [EnumString("shadowedSquares")]
    ShadowedSquares = 151,
    [EnumString("sharksTeeth")]
    SharksTeeth = 152,
    [EnumString("shorebirdTracks")]
    ShorebirdTracks = 153,
    [EnumString("skyrocket")]
    Skyrocket = 154,
    [EnumString("snowflakeFancy")]
    SnowflakeFancy = 155,
    [EnumString("snowflakes")]
    Snowflakes = 156,
    [EnumString("sombrero")]
    Sombrero = 157,
    [EnumString("southwest")]
    Southwest = 158,
    [EnumString("stars")]
    Stars = 159,
    [EnumString("starsTop")]
    StarsTop = 160,
    [EnumString("stars3d")]
    Stars3d = 161,
    [EnumString("starsBlack")]
    StarsBlack = 162,
    [EnumString("starsShadowed")]
    StarsShadowed = 163,
    [EnumString("sun")]
    Sun = 164,
    [EnumString("swirligig")]
    Swirligig = 165,
    [EnumString("tornPaper")]
    TornPaper = 166,
    [EnumString("tornPaperBlack")]
    TornPaperBlack = 167,
    [EnumString("trees")]
    Trees = 168,
    [EnumString("triangleParty")]
    TriangleParty = 169,
    [EnumString("triangles")]
    Triangles = 170,
    [EnumString("triangle1")]
    Triangle1 = 177,
    [EnumString("triangle2")]
    Triangle2 = 178,
    [EnumString("triangleCircle1")]
    TriangleCircle1 = 179,
    [EnumString("triangleCircle2")]
    TriangleCircle2 = 180,
    [EnumString("shapes1")]
    Shapes1 = 181,
    [EnumString("shapes2")]
    Shapes2 = 182,
    [EnumString("twistedLines1")]
    TwistedLines1 = 183,
    [EnumString("twistedLines2")]
    TwistedLines2 = 184,
    [EnumString("vine")]
    Vine = 185,
    [EnumString("waveline")]
    Waveline = 186,
    [EnumString("weavingAngles")]
    WeavingAngles = 187,
    [EnumString("weavingBraid")]
    WeavingBraid = 188,
    [EnumString("weavingRibbon")]
    WeavingRibbon = 189,
    [EnumString("weavingStrips")]
    WeavingStrips = 190,
    [EnumString("whiteFlowers")]
    WhiteFlowers = 191,
    [EnumString("woodwork")]
    Woodwork = 192,
    [EnumString("xIllusions")]
    XIllusions = 193,
    [EnumString("zanyTriangles")]
    ZanyTriangles = 194,
    [EnumString("zigZag")]
    ZigZag = 195,
    [EnumString("zigZagStitch")]
    ZigZagStitch = 196,
    [EnumString("custom")]
    Custom,
  }
}

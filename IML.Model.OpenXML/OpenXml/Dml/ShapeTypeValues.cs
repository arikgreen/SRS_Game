using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("ShapeType")]
  public enum ShapeTypeValues
  {
    [EnumString("line")]
    Line = 0,
    [EnumString("lineInv")]
    LineInv,
    [EnumString("triangle")]
    Triangle = 2,
    [EnumString("rtTriangle")]
    RtTriangle,
    [EnumString("rect")]
    Rect,
    [EnumString("diamond")]
    Diamond = 5,
    [EnumString("parallelogram")]
    Parallelogram = 6,
    [EnumString("trapezoid")]
    Trapezoid = 7,
    [EnumString("nonIsoscelesTrapezoid")]
    NonIsoscelesTrapezoid = 8,
    [EnumString("pentagon")]
    Pentagon = 9,
    [EnumString("hexagon")]
    Hexagon = 10,
    [EnumString("heptagon")]
    Heptagon = 11,
    [EnumString("octagon")]
    Octagon = 12,
    [EnumString("decagon")]
    Decagon = 13,
    [EnumString("dodecagon")]
    Dodecagon = 14,
    [EnumString("star4")]
    Star4 = 15,
    [EnumString("star5")]
    Star5 = 16,
    [EnumString("star6")]
    Star6 = 17,
    [EnumString("star7")]
    Star7 = 18,
    [EnumString("star8")]
    Star8 = 19,
    [EnumString("star10")]
    Star10 = 20,
    [EnumString("star12")]
    Star12 = 21,
    [EnumString("star16")]
    Star16 = 22,
    [EnumString("star24")]
    Star24 = 23,
    [EnumString("star32")]
    Star32 = 24,
    [EnumString("roundRect")]
    RoundRect,
    [EnumString("round1Rect")]
    Round1Rect,
    [EnumString("round2SameRect")]
    Round2SameRect,
    [EnumString("round2DiagRect")]
    Round2DiagRect,
    [EnumString("snipRoundRect")]
    SnipRoundRect,
    [EnumString("snip1Rect")]
    Snip1Rect,
    [EnumString("snip2SameRect")]
    Snip2SameRect,
    [EnumString("snip2DiagRect")]
    Snip2DiagRect,
    [EnumString("plaque")]
    Plaque = 33,
    [EnumString("ellipse")]
    Ellipse = 34,
    [EnumString("teardrop")]
    Teardrop = 35,
    [EnumString("homePlate")]
    HomePlate = 36,
    [EnumString("chevron")]
    Chevron = 37,
    [EnumString("pieWedge")]
    PieWedge = 38,
    [EnumString("pie")]
    Pie = 39,
    [EnumString("blockArc")]
    BlockArc = 40,
    [EnumString("donut")]
    Donut = 41,
    [EnumString("noSmoking")]
    NoSmoking = 42,
    [EnumString("rightArrow")]
    RightArrow = 43,
    [EnumString("leftArrow")]
    LeftArrow = 44,
    [EnumString("upArrow")]
    UpArrow = 45,
    [EnumString("downArrow")]
    DownArrow = 46,
    [EnumString("stripedRightArrow")]
    StripedRightArrow = 47,
    [EnumString("notchedRightArrow")]
    NotchedRightArrow = 48,
    [EnumString("bentUpArrow")]
    BentUpArrow = 49,
    [EnumString("leftRightArrow")]
    LeftRightArrow = 50,
    [EnumString("upDownArrow")]
    UpDownArrow = 51,
    [EnumString("leftUpArrow")]
    LeftUpArrow = 52,
    [EnumString("leftRightUpArrow")]
    LeftRightUpArrow = 53,
    [EnumString("quadArrow")]
    QuadArrow = 54,
    [EnumString("leftArrowCallout")]
    LeftArrowCallout = 55,
    [EnumString("rightArrowCallout")]
    RightArrowCallout = 56,
    [EnumString("upArrowCallout")]
    UpArrowCallout = 57,
    [EnumString("downArrowCallout")]
    DownArrowCallout = 58,
    [EnumString("leftRightArrowCallout")]
    LeftRightArrowCallout = 59,
    [EnumString("upDownArrowCallout")]
    UpDownArrowCallout = 60,
    [EnumString("quadArrowCallout")]
    QuadArrowCallout = 61,
    [EnumString("bentArrow")]
    BentArrow = 62,
    [EnumString("uturnArrow")]
    UturnArrow,
    [EnumString("circularArrow")]
    CircularArrow = 64,
    [EnumString("leftCircularArrow")]
    LeftCircularArrow = 65,
    [EnumString("leftRightCircularArrow")]
    LeftRightCircularArrow = 66,
    [EnumString("curvedRightArrow")]
    CurvedRightArrow = 67,
    [EnumString("curvedLeftArrow")]
    CurvedLeftArrow = 68,
    [EnumString("curvedUpArrow")]
    CurvedUpArrow = 69,
    [EnumString("curvedDownArrow")]
    CurvedDownArrow = 70,
    [EnumString("swooshArrow")]
    SwooshArrow = 71,
    [EnumString("cube")]
    Cube = 72,
    [EnumString("can")]
    Can = 73,
    [EnumString("lightningBolt")]
    LightningBolt = 74,
    [EnumString("heart")]
    Heart = 75,
    [EnumString("sun")]
    Sun = 76,
    [EnumString("moon")]
    Moon = 77,
    [EnumString("smileyFace")]
    SmileyFace = 78,
    [EnumString("irregularSeal1")]
    IrregularSeal1 = 79,
    [EnumString("irregularSeal2")]
    IrregularSeal2 = 80,
    [EnumString("foldedCorner")]
    FoldedCorner = 81,
    [EnumString("bevel")]
    Bevel = 82,
    [EnumString("frame")]
    Frame = 83,
    [EnumString("halfFrame")]
    HalfFrame = 84,
    [EnumString("corner")]
    Corner = 85,
    [EnumString("diagStripe")]
    DiagStripe,
    [EnumString("chord")]
    Chord = 87,
    [EnumString("arc")]
    Arc = 88,
    [EnumString("leftBracket")]
    LeftBracket = 89,
    [EnumString("rightBracket")]
    RightBracket = 90,
    [EnumString("leftBrace")]
    LeftBrace = 91,
    [EnumString("rightBrace")]
    RightBrace = 92,
    [EnumString("bracketPair")]
    BracketPair = 93,
    [EnumString("bracePair")]
    BracePair = 94,
    [EnumString("straightConnector1")]
    StraightConnector1 = 95,
    [EnumString("bentConnector2")]
    BentConnector2 = 96,
    [EnumString("bentConnector3")]
    BentConnector3 = 97,
    [EnumString("bentConnector4")]
    BentConnector4 = 98,
    [EnumString("bentConnector5")]
    BentConnector5 = 99,
    [EnumString("curvedConnector2")]
    CurvedConnector2 = 100,
    [EnumString("curvedConnector3")]
    CurvedConnector3 = 101,
    [EnumString("curvedConnector4")]
    CurvedConnector4 = 102,
    [EnumString("curvedConnector5")]
    CurvedConnector5 = 103,
    [EnumString("callout1")]
    Callout1 = 104,
    [EnumString("callout2")]
    Callout2 = 105,
    [EnumString("callout3")]
    Callout3 = 106,
    [EnumString("accentCallout1")]
    AccentCallout1 = 107,
    [EnumString("accentCallout2")]
    AccentCallout2 = 108,
    [EnumString("accentCallout3")]
    AccentCallout3 = 109,
    [EnumString("borderCallout1")]
    BorderCallout1 = 110,
    [EnumString("borderCallout2")]
    BorderCallout2 = 111,
    [EnumString("borderCallout3")]
    BorderCallout3 = 112,
    [EnumString("accentBorderCallout1")]
    AccentBorderCallout1 = 113,
    [EnumString("accentBorderCallout2")]
    AccentBorderCallout2 = 114,
    [EnumString("accentBorderCallout3")]
    AccentBorderCallout3 = 115,
    [EnumString("wedgeRectCallout")]
    WedgeRectCallout,
    [EnumString("wedgeRoundRectCallout")]
    WedgeRoundRectCallout,
    [EnumString("wedgeEllipseCallout")]
    WedgeEllipseCallout = 118,
    [EnumString("cloudCallout")]
    CloudCallout = 119,
    [EnumString("cloud")]
    Cloud = 120,
    [EnumString("ribbon")]
    Ribbon = 121,
    [EnumString("ribbon2")]
    Ribbon2 = 122,
    [EnumString("ellipseRibbon")]
    EllipseRibbon = 123,
    [EnumString("ellipseRibbon2")]
    EllipseRibbon2 = 124,
    [EnumString("leftRightRibbon")]
    LeftRightRibbon = 125,
    [EnumString("verticalScroll")]
    VerticalScroll = 126,
    [EnumString("horizontalScroll")]
    HorizontalScroll = 127,
    [EnumString("wave")]
    Wave = 128,
    [EnumString("doubleWave")]
    DoubleWave = 129,
    [EnumString("plus")]
    Plus = 130,
    [EnumString("flowChartProcess")]
    FlowChartProcess = 131,
    [EnumString("flowChartDecision")]
    FlowChartDecision = 132,
    [EnumString("flowChartInputOutput")]
    FlowChartInputOutput = 133,
    [EnumString("flowChartPredefinedProcess")]
    FlowChartPredefinedProcess = 134,
    [EnumString("flowChartInternalStorage")]
    FlowChartInternalStorage = 135,
    [EnumString("flowChartDocument")]
    FlowChartDocument = 136,
    [EnumString("flowChartMultidocument")]
    FlowChartMultidocument = 137,
    [EnumString("flowChartTerminator")]
    FlowChartTerminator = 138,
    [EnumString("flowChartPreparation")]
    FlowChartPreparation = 139,
    [EnumString("flowChartManualInput")]
    FlowChartManualInput = 140,
    [EnumString("flowChartManualOperation")]
    FlowChartManualOperation = 141,
    [EnumString("flowChartConnector")]
    FlowChartConnector = 142,
    [EnumString("flowChartPunchedCard")]
    FlowChartPunchedCard = 143,
    [EnumString("flowChartPunchedTape")]
    FlowChartPunchedTape = 144,
    [EnumString("flowChartSummingJunction")]
    FlowChartSummingJunction = 145,
    [EnumString("flowChartOr")]
    FlowChartOr = 146,
    [EnumString("flowChartCollate")]
    FlowChartCollate = 147,
    [EnumString("flowChartSort")]
    FlowChartSort = 148,
    [EnumString("flowChartExtract")]
    FlowChartExtract = 149,
    [EnumString("flowChartMerge")]
    FlowChartMerge = 150,
    [EnumString("flowChartOfflineStorage")]
    FlowChartOfflineStorage = 151,
    [EnumString("flowChartOnlineStorage")]
    FlowChartOnlineStorage = 152,
    [EnumString("flowChartMagneticTape")]
    FlowChartMagneticTape = 153,
    [EnumString("flowChartMagneticDisk")]
    FlowChartMagneticDisk = 154,
    [EnumString("flowChartMagneticDrum")]
    FlowChartMagneticDrum = 155,
    [EnumString("flowChartDisplay")]
    FlowChartDisplay = 156,
    [EnumString("flowChartDelay")]
    FlowChartDelay = 157,
    [EnumString("flowChartAlternateProcess")]
    FlowChartAlternateProcess = 158,
    [EnumString("flowChartOffpageConnector")]
    FlowChartOffpageConnector = 159,
    [EnumString("actionButtonBlank")]
    ActionButtonBlank = 160,
    [EnumString("actionButtonHome")]
    ActionButtonHome = 161,
    [EnumString("actionButtonHelp")]
    ActionButtonHelp = 162,
    [EnumString("actionButtonInformation")]
    ActionButtonInformation = 163,
    [EnumString("actionButtonForwardNext")]
    ActionButtonForwardNext = 164,
    [EnumString("actionButtonBackPrevious")]
    ActionButtonBackPrevious = 165,
    [EnumString("actionButtonEnd")]
    ActionButtonEnd = 166,
    [EnumString("actionButtonBeginning")]
    ActionButtonBeginning = 167,
    [EnumString("actionButtonReturn")]
    ActionButtonReturn = 168,
    [EnumString("actionButtonDocument")]
    ActionButtonDocument = 169,
    [EnumString("actionButtonSound")]
    ActionButtonSound = 170,
    [EnumString("actionButtonMovie")]
    ActionButtonMovie = 171,
    [EnumString("gear6")]
    Gear6 = 172,
    [EnumString("gear9")]
    Gear9 = 173,
    [EnumString("funnel")]
    Funnel = 174,
    [EnumString("mathPlus")]
    MathPlus = 175,
    [EnumString("mathMinus")]
    MathMinus = 176,
    [EnumString("mathMultiply")]
    MathMultiply = 177,
    [EnumString("mathDivide")]
    MathDivide = 178,
    [EnumString("mathEqual")]
    MathEqual = 179,
    [EnumString("mathNotEqual")]
    MathNotEqual = 180,
    [EnumString("cornerTabs")]
    CornerTabs = 181,
    [EnumString("squareTabs")]
    SquareTabs = 182,
    [EnumString("plaqueTabs")]
    PlaqueTabs = 183,
    [EnumString("chartX")]
    ChartX = 184,
    [EnumString("chartStar")]
    ChartStar = 185,
    [EnumString("chartPlus")]
    ChartPlus = 186,
  }
}

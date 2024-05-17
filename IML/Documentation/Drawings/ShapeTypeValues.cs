using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iml.Documentation.Drawings
{
  /// <summary>
  /// Preset Shape Types
  /// </summary>
  public enum ShapeTypeValues
  {
    /// <summary>
    /// LineShape
    /// </summary>
    [OpenXMLAttributeValue("line")]
    Line = 0,
    
    /// <summary>
    ///    Line Inverse Shape.
    /// </summary> 
    [OpenXMLAttributeValue("lineInv")]
    LineInverse = 1,
    
    /// <summary>
    ///  Triangle Shape.
    /// </summary> 
    [OpenXMLAttributeValue("triangle")]
    Triangle = 2,
    
    /// <summary>
    ///  Right Triangle Shape.
    /// </summary> 
    [OpenXMLAttributeValue("rtTriangle")]
    RightTriangle = 3,
    
    /// <summary>
    ///  Rectangle Shape.
    /// </summary> 
    [OpenXMLAttributeValue("rect")]
    Rectangle = 4,
    
    /// <summary>
    ///  Diamond Shape.
    /// </summary> 
    [OpenXMLAttributeValue("diamond")]
    Diamond = 5,
    
    /// <summary>
    ///  Parallelogram Shape.
    /// </summary> 
    [OpenXMLAttributeValue("parallelogram")]
    Parallelogram = 6,
    
    /// <summary>
    ///  Trapezoid Shape.
    /// </summary> 
    [OpenXMLAttributeValue("trapezoid")]
    Trapezoid = 7,
    
    /// <summary>
    ///  Non-Isosceles Trapezoid Shape.
    /// </summary> 
    [OpenXMLAttributeValue("nonIsoscelesTrapezoid")]
    NonIsoscelesTrapezoid = 8,
    
    /// <summary>
    ///  Pentagon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("pentagon")]
    Pentagon = 9,
    
    /// <summary>
    ///  Hexagon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("hexagon")]
    Hexagon = 10,

    /// <summary>
    ///    Heptagon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("heptagon")]
    Heptagon = 11,

    /// <summary>
    ///    Octagon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("octagon")]
    Octagon = 12,

    /// <summary>
    ///    Decagon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("decagon")]
    Decagon = 13,

    /// <summary>
    ///    Dodecagon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("dodecagon")]
    Dodecagon = 14,

    /// <summary>
    ///    Four Pointed Star Shape.
    /// </summary> "star4".
    [OpenXMLAttributeValue("star4")]
    Star4 = 15,

    /// <summary>
    ///    Five Pointed Star Shape.
    /// </summary> "star5".
    [OpenXMLAttributeValue("star5")]
    Star5 = 16,

    /// <summary>
    ///    Six Pointed Star Shape.
    /// </summary> "star6".
    [OpenXMLAttributeValue("star6")]
    Star6 = 17,

    /// <summary>
    ///    Seven Pointed Star Shape.
    /// </summary> "star7".
    [OpenXMLAttributeValue("star7")]
    Star7 = 18,

    /// <summary>
    ///    Eight Pointed Star Shape.
    /// </summary> "star8".
    [OpenXMLAttributeValue("star8")]
    Star8 = 19,

    /// <summary>
    ///    Ten Pointed Star Shape.
    /// </summary> "star10".
    [OpenXMLAttributeValue("star10")]
    Star10 = 20,

    /// <summary>
    ///    Twelve Pointed Star Shape.
    /// </summary> "star12".
    [OpenXMLAttributeValue("star12")]
    Star12 = 21,

    /// <summary>
    ///    Sixteen Pointed Star Shape.
    /// </summary> "star16".
    [OpenXMLAttributeValue("star16")]
    Star16 = 22,

    /// <summary>
    ///    Twenty Four Pointed Star Shape.
    /// </summary> "star24".
    [OpenXMLAttributeValue("star24")]
    Star24 = 23,

    /// <summary>
    ///    Thirty Two Pointed Star Shape.
    /// </summary> "star32".
    [OpenXMLAttributeValue("star32")]
    Star32 = 24,

    /// <summary>
    ///    Round Corner Rectangle Shape.
    /// </summary> 
    [OpenXMLAttributeValue("roundRect")]
    RoundRectangle = 25,

    /// <summary>
    ///    One Round Corner Rectangle Shape.
    /// </summary> "round1Rect".
    [OpenXMLAttributeValue("round1Rect")]
    Round1Rectangle = 26,

    /// <summary>
    ///    Two Same-side Round Corner Rectangle Shape.
    /// </summary> "round2SameRect".
    [OpenXMLAttributeValue("round2SameRect")]
    Round2SameRectangle = 27,

    /// <summary>
    ///    Two Diagonal Round Corner Rectangle Shape.
    /// </summary> "round2DiagRect".
    [OpenXMLAttributeValue("round2DiagRect")]
    Round2DiagonalRectangle = 28,

    /// <summary>
    ///    One Snip One Round Corner Rectangle Shape.
    /// </summary> 
    [OpenXMLAttributeValue("snipRoundRect")]
    SnipRoundRectangle = 29,

    /// <summary>
    ///    One Snip Corner Rectangle Shape.
    /// </summary> "snip1Rect".
    [OpenXMLAttributeValue("snip1Rect")]
    Snip1Rectangle = 30,

    /// <summary>
    ///    Two Same-side Snip Corner Rectangle Shape.
    /// </summary> "snip2SameRect".
    [OpenXMLAttributeValue("snip2SameRect")]
    Snip2SameRectangle = 31,

    /// <summary>
    ///    Two Diagonal Snip Corner Rectangle Shape.
    /// </summary> "snip2DiagRect".
    [OpenXMLAttributeValue("snip2DiagRect")]
    Snip2DiagonalRectangle = 32,

    /// <summary>
    ///    Plaque Shape.
    /// </summary> 
    [OpenXMLAttributeValue("plaque")]
    Plaque = 33,

    /// <summary>
    ///    Ellipse Shape.
    /// </summary> 
    [OpenXMLAttributeValue("ellipse")]
    Ellipse = 34,

    /// <summary>
    ///    Teardrop Shape.
    /// </summary> 
    [OpenXMLAttributeValue("teardrop")]
    Teardrop = 35,

    /// <summary>
    ///    Home Plate Shape.
    /// </summary> 
    [OpenXMLAttributeValue("homePlate")]
    HomePlate = 36,

    /// <summary>
    ///    Chevron Shape.
    /// </summary> 
    [OpenXMLAttributeValue("chevron")]
    Chevron = 37,

    /// <summary>
    ///    Pie Wedge Shape.
    /// </summary> 
    [OpenXMLAttributeValue("pieWedge")]
    PieWedge = 38,

    /// <summary>
    ///    Pie Shape.
    /// </summary> 
    [OpenXMLAttributeValue("pie")]
    Pie = 39,

    /// <summary>
    ///    Block Arc Shape.
    /// </summary> 
    [OpenXMLAttributeValue("blockArc")]
    BlockArc = 40,

    /// <summary>
    ///    Donut Shape.
    /// </summary> 
    [OpenXMLAttributeValue("donut")]
    Donut = 41,

    /// <summary>
    ///    No Smoking Shape.
    /// </summary> 
    [OpenXMLAttributeValue("noSmoking")]
    NoSmoking = 42,

    /// <summary>
    ///    Right Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("rightArrow")]
    RightArrow = 43,

    /// <summary>
    ///    Left Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftArrow")]
    LeftArrow = 44,

    /// <summary>
    ///    Up Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("upArrow")]
    UpArrow = 45,

    /// <summary>
    ///    Down Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("downArrow")]
    DownArrow = 46,

    /// <summary>
    ///    Striped Right Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("stripedRightArrow")]
    StripedRightArrow = 47,

    /// <summary>
    ///    Notched Right Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("notchedRightArrow")]
    NotchedRightArrow = 48,

    /// <summary>
    ///    Bent Up Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("bentUpArrow")]
    BentUpArrow = 49,

    /// <summary>
    ///    Left Right Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftRightArrow")]
    LeftRightArrow = 50,

    /// <summary>
    ///    Up Down Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("upDownArrow")]
    UpDownArrow = 51,

    /// <summary>
    ///    Left Up Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftUpArrow")]
    LeftUpArrow = 52,

    /// <summary>
    ///    Left Right Up Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftRightUpArrow")]
    LeftRightUpArrow = 53,

    /// <summary>
    ///    Quad-Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("quadArrow")]
    QuadArrow = 54,

    /// <summary>
    ///    Callout Left Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftArrowCallout")]
    LeftArrowCallout = 55,

    /// <summary>
    ///    Callout Right Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("rightArrowCallout")]
    RightArrowCallout = 56,

    /// <summary>
    ///    Callout Up Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("upArrowCallout")]
    UpArrowCallout = 57,

    /// <summary>
    ///    Callout Down Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("downArrowCallout")]
    DownArrowCallout = 58,

    /// <summary>
    ///    Callout Left Right Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftRightArrowCallout")]
    LeftRightArrowCallout = 59,

    /// <summary>
    ///    Callout Up Down Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("upDownArrowCallout")]
    UpDownArrowCallout = 60,

    /// <summary>
    ///    Callout Quad-Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("quadArrowCallout")]
    QuadArrowCallout = 61,

    /// <summary>
    ///    Bent Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("bentArrow")]
    BentArrow = 62,

    /// <summary>
    ///    U-Turn Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("uturnArrow")]
    UTurnArrow = 63,

    /// <summary>
    ///    Circular Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("circularArrow")]
    CircularArrow = 64,

    /// <summary>
    ///    Left Circular Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftCircularArrow")]
    LeftCircularArrow = 65,

    /// <summary>
    ///    Left Right Circular Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftRightCircularArrow")]
    LeftRightCircularArrow = 66,

    /// <summary>
    ///    Curved Right Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("curvedRightArrow")]
    CurvedRightArrow = 67,

    /// <summary>
    ///    Curved Left Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("curvedLeftArrow")]
    CurvedLeftArrow = 68,

    /// <summary>
    ///    Curved Up Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("curvedUpArrow")]
    CurvedUpArrow = 69,

    /// <summary>
    ///    Curved Down Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("curvedDownArrow")]
    CurvedDownArrow = 70,

    /// <summary>
    ///    Swoosh Arrow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("swooshArrow")]
    SwooshArrow = 71,

    /// <summary>
    ///    Cube Shape.
    /// </summary> 
    [OpenXMLAttributeValue("cube")]
    Cube = 72,

    /// <summary>
    ///    Can Shape.
    /// </summary> 
    [OpenXMLAttributeValue("can")]
    Can = 73,

    /// <summary>
    ///    Lightning Bolt Shape.
    /// </summary> 
    [OpenXMLAttributeValue("lightningBolt")]
    LightningBolt = 74,

    /// <summary>
    ///    Heart Shape.
    /// </summary> 
    [OpenXMLAttributeValue("heart")]
    Heart = 75,

    /// <summary>
    ///    Sun Shape.
    /// </summary> 
    [OpenXMLAttributeValue("sun")]
    Sun = 76,

    /// <summary>
    ///    Moon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("moon")]
    Moon = 77,

    /// <summary>
    ///    Smiley Face Shape.
    /// </summary> 
    [OpenXMLAttributeValue("smileyFace")]
    SmileyFace = 78,

    /// <summary>
    ///    Irregular Seal 1 Shape.
    /// </summary> "irregularSeal1".
    [OpenXMLAttributeValue("irregularSeal1")]
    IrregularSeal1 = 79,

    /// <summary>
    ///    Irregular Seal 2 Shape.
    /// </summary> "irregularSeal2".
    [OpenXMLAttributeValue("irregularSeal2")]
    IrregularSeal2 = 80,

    /// <summary>
    ///    Folded Corner Shape.
    /// </summary> 
    [OpenXMLAttributeValue("foldedCorner")]
    FoldedCorner = 81,

    /// <summary>
    ///    Bevel Shape.
    /// </summary> 
    [OpenXMLAttributeValue("bevel")]
    Bevel = 82,

    /// <summary>
    ///    Frame Shape.
    /// </summary> 
    [OpenXMLAttributeValue("frame")]
    Frame = 83,

    /// <summary>
    ///    Half Frame Shape.
    /// </summary> 
    [OpenXMLAttributeValue("halfFrame")]
    HalfFrame = 84,

    /// <summary>
    ///    Corner Shape.
    /// </summary> 
    [OpenXMLAttributeValue("corner")]
    Corner = 85,

    /// <summary>
    ///    Diagonal Stripe Shape.
    /// </summary> 
    [OpenXMLAttributeValue("diagStripe")]
    DiagonalStripe = 86,

    /// <summary>
    ///    Chord Shape.
    /// </summary> 
    [OpenXMLAttributeValue("chord")]
    Chord = 87,

    /// <summary>
    ///    Curved Arc Shape.
    /// </summary> 
    [OpenXMLAttributeValue("arc")]
    Arc = 88,

    /// <summary>
    ///    Left Bracket Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftBracket")]
    LeftBracket = 89,

    /// <summary>
    ///    Right Bracket Shape.
    /// </summary> 
    [OpenXMLAttributeValue("rightBracket")]
    RightBracket = 90,

    /// <summary>
    ///    Left Brace Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftBrace")]
    LeftBrace = 91,

    /// <summary>
    ///    Right Brace Shape.
    /// </summary> 
    [OpenXMLAttributeValue("rightBrace")]
    RightBrace = 92,

    /// <summary>
    ///    Bracket Pair Shape.
    /// </summary> 
    [OpenXMLAttributeValue("bracketPair")]
    BracketPair = 93,

    /// <summary>
    ///    Brace Pair Shape.
    /// </summary> 
    [OpenXMLAttributeValue("bracePair")]
    BracePair = 94,

    /// <summary>
    ///    Straight Connector 1 Shape.
    /// </summary> "straightConnector1".
    [OpenXMLAttributeValue("straightConnector1")]
    StraightConnector1 = 95,

    /// <summary>
    ///    Bent Connector 2 Shape.
    /// </summary> "bentConnector2".
    [OpenXMLAttributeValue("bentConnector2")]
    BentConnector2 = 96,

    /// <summary>
    ///    Bent Connector 3 Shape.
    /// </summary> "bentConnector3".
    [OpenXMLAttributeValue("bentConnector3")]
    BentConnector3 = 97,

    /// <summary>
    ///    Bent Connector 4 Shape.
    /// </summary> "bentConnector4".
    [OpenXMLAttributeValue("bentConnector4")]
    BentConnector4 = 98,

    /// <summary>
    ///    Bent Connector 5 Shape.
    /// </summary> "bentConnector5".
    [OpenXMLAttributeValue("bentConnector5")]
    BentConnector5 = 99,

    /// <summary>
    ///    Curved Connector 2 Shape.
    /// </summary> "curvedConnector2".
    [OpenXMLAttributeValue("curvedConnector2")]
    CurvedConnector2 = 100,

    /// <summary>
    ///    Curved Connector 3 Shape.
    /// </summary> "curvedConnector3".
    [OpenXMLAttributeValue("curvedConnector3")]
    CurvedConnector3 = 101,

    /// <summary>
    ///    Curved Connector 4 Shape.
    /// </summary> "curvedConnector4".
    [OpenXMLAttributeValue("curvedConnector4")]
    CurvedConnector4 = 102,

    /// <summary>
    ///    Curved Connector 5 Shape.
    /// </summary> "curvedConnector5".
    [OpenXMLAttributeValue("curvedConnector5")]
    CurvedConnector5 = 103,

    /// <summary>
    ///    Callout 1 Shape.
    /// </summary> "callout1".
    [OpenXMLAttributeValue("callout1")]
    Callout1 = 104,

    /// <summary>
    ///    Callout 2 Shape.
    /// </summary> "callout2".
    [OpenXMLAttributeValue("callout2")]
    Callout2 = 105,

    /// <summary>
    ///    Callout 3 Shape.
    /// </summary> "callout3".
    [OpenXMLAttributeValue("callout3")]
    Callout3 = 106,

    /// <summary>
    ///    Callout 1 Shape.
    /// </summary> "accentCallout1".
    [OpenXMLAttributeValue("accentCallout1")]
    AccentCallout1 = 107,

    /// <summary>
    ///    Callout 2 Shape.
    /// </summary> "accentCallout2".
    [OpenXMLAttributeValue("accentCallout2")]
    AccentCallout2 = 108,

    /// <summary>
    ///    Callout 3 Shape.
    /// </summary> "accentCallout3".
    [OpenXMLAttributeValue("accentCallout3")]
    AccentCallout3 = 109,

    /// <summary>
    ///    Callout 1 with Border Shape.
    /// </summary> "borderCallout1".
    [OpenXMLAttributeValue("borderCallout1")]
    BorderCallout1 = 110,

    /// <summary>
    ///    Callout 2 with Border Shape.
    /// </summary> "borderCallout2".
    [OpenXMLAttributeValue("borderCallout2")]
    BorderCallout2 = 111,

    /// <summary>
    ///    Callout 3 with Border Shape.
    /// </summary> "borderCallout3".
    [OpenXMLAttributeValue("borderCallout3")]
    BorderCallout3 = 112,

    /// <summary>
    ///    Callout 1 with Border and Accent Shape.
    /// </summary> "accentBorderCallout1".
    [OpenXMLAttributeValue("accentBorderCallout1")]
    AccentBorderCallout1 = 113,

    /// <summary>
    ///    Callout 2 with Border and Accent Shape.
    /// </summary> "accentBorderCallout2".
    [OpenXMLAttributeValue("accentBorderCallout2")]
    AccentBorderCallout2 = 114,

    /// <summary>
    ///    Callout 3 with Border and Accent Shape.
    /// </summary> "accentBorderCallout3".
    [OpenXMLAttributeValue("accentBorderCallout3")]
    AccentBorderCallout3 = 115,

    /// <summary>
    ///    Callout Wedge Rectangle Shape.
    /// </summary> 
    [OpenXMLAttributeValue("wedgeRectCallout")]
    WedgeRectangleCallout = 116,

    /// <summary>
    ///    Callout Wedge Round Rectangle Shape.
    /// </summary> 
    [OpenXMLAttributeValue("wedgeRoundRectCallout")]
    WedgeRoundRectangleCallout = 117,

    /// <summary>
    ///    Callout Wedge Ellipse Shape.
    /// </summary> 
    [OpenXMLAttributeValue("wedgeEllipseCallout")]
    WedgeEllipseCallout = 118,

    /// <summary>
    ///    Callout Cloud Shape.
    /// </summary> 
    [OpenXMLAttributeValue("cloudCallout")]
    CloudCallout = 119,

    /// <summary>
    ///    Cloud Shape.
    /// </summary> 
    [OpenXMLAttributeValue("cloud")]
    Cloud = 120,

    /// <summary>
    ///    Ribbon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("ribbon")]
    Ribbon = 121,

    /// <summary>
    ///    Ribbon 2 Shape.
    /// </summary> "ribbon2".
    [OpenXMLAttributeValue("ribbon2")]
    Ribbon2 = 122,

    /// <summary>
    ///    Ellipse Ribbon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("ellipseRibbon")]
    EllipseRibbon = 123,

    /// <summary>
    ///    Ellipse Ribbon 2 Shape.
    /// </summary> "ellipseRibbon2".
    [OpenXMLAttributeValue("ellipseRibbon2")]
    EllipseRibbon2 = 124,

    /// <summary>
    ///    Left Right Ribbon Shape.
    /// </summary> 
    [OpenXMLAttributeValue("leftRightRibbon")]
    LeftRightRibbon = 125,

    /// <summary>
    ///    Vertical Scroll Shape.
    /// </summary> 
    [OpenXMLAttributeValue("verticalScroll")]
    VerticalScroll = 126,

    /// <summary>
    ///    Horizontal Scroll Shape.
    /// </summary> 
    [OpenXMLAttributeValue("horizontalScroll")]
    HorizontalScroll = 127,

    /// <summary>
    ///    Wave Shape.
    /// </summary> 
    [OpenXMLAttributeValue("wave")]
    Wave = 128,

    /// <summary>
    ///    Double Wave Shape.
    /// </summary> 
    [OpenXMLAttributeValue("doubleWave")]
    DoubleWave = 129,

    /// <summary>
    ///    Plus Shape.
    /// </summary> 
    [OpenXMLAttributeValue("plus")]
    Plus = 130,

    /// <summary>
    ///    Process Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartProcess")]
    FlowChartProcess = 131,

    /// <summary>
    ///    Decision Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartDecision")]
    FlowChartDecision = 132,

    /// <summary>
    ///    Input Output Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartInputOutput")]
    FlowChartInputOutput = 133,

    /// <summary>
    ///    Predefined Process Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartPredefinedProcess")]
    FlowChartPredefinedProcess = 134,

    /// <summary>
    ///    Internal Storage Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartInternalStorage")]
    FlowChartInternalStorage = 135,

    /// <summary>
    ///    Document Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartDocument")]
    FlowChartDocument = 136,

    /// <summary>
    ///    Multi-Document Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartMultidocument")]
    FlowChartMultidocument = 137,

    /// <summary>
    ///    Terminator Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartTerminator")]
    FlowChartTerminator = 138,

    /// <summary>
    ///    Preparation Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartPreparation")]
    FlowChartPreparation = 139,

    /// <summary>
    ///    Manual Input Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartManualInput")]
    FlowChartManualInput = 140,

    /// <summary>
    ///    Manual Operation Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartManualOperation")]
    FlowChartManualOperation = 141,

    /// <summary>
    ///    Connector Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartConnector")]
    FlowChartConnector = 142,

    /// <summary>
    ///    Punched Card Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartPunchedCard")]
    FlowChartPunchedCard = 143,

    /// <summary>
    ///    Punched Tape Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartPunchedTape")]
    FlowChartPunchedTape = 144,

    /// <summary>
    ///    Summing Junction Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartSummingJunction")]
    FlowChartSummingJunction = 145,

    /// <summary>
    ///    Or Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartOr")]
    FlowChartOr = 146,

    /// <summary>
    ///    Collate Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartCollate")]
    FlowChartCollate = 147,

    /// <summary>
    ///    Sort Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartSort")]
    FlowChartSort = 148,

    /// <summary>
    ///    Extract Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartExtract")]
    FlowChartExtract = 149,

    /// <summary>
    ///    Merge Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartMerge")]
    FlowChartMerge = 150,

    /// <summary>
    ///    Offline Storage Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartOfflineStorage")]
    FlowChartOfflineStorage = 151,

    /// <summary>
    ///    Online Storage Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartOnlineStorage")]
    FlowChartOnlineStorage = 152,

    /// <summary>
    ///    Magnetic Tape Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartMagneticTape")]
    FlowChartMagneticTape = 153,

    /// <summary>
    ///    Magnetic Disk Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartMagneticDisk")]
    FlowChartMagneticDisk = 154,

    /// <summary>
    ///    Magnetic Drum Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartMagneticDrum")]
    FlowChartMagneticDrum = 155,

    /// <summary>
    ///    Display Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartDisplay")]
    FlowChartDisplay = 156,

    /// <summary>
    ///    Delay Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartDelay")]
    FlowChartDelay = 157,

    /// <summary>
    ///    Alternate Process Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartAlternateProcess")]
    FlowChartAlternateProcess = 158,

    /// <summary>
    ///    Off-Page Connector Flow Shape.
    /// </summary> 
    [OpenXMLAttributeValue("flowChartOffpageConnector")]
    FlowChartOffpageConnector = 159,

    /// <summary>
    ///    Blank Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonBlank")]
    ActionButtonBlank = 160,

    /// <summary>
    ///    Home Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonHome")]
    ActionButtonHome = 161,

    /// <summary>
    ///    Help Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonHelp")]
    ActionButtonHelp = 162,

    /// <summary>
    ///    Information Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonInformation")]
    ActionButtonInformation = 163,

    /// <summary>
    ///    Forward or Next Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonForwardNext")]
    ActionButtonForwardNext = 164,

    /// <summary>
    ///    Back or Previous Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonBackPrevious")]
    ActionButtonBackPrevious = 165,

    /// <summary>
    ///    End Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonEnd")]
    ActionButtonEnd = 166,

    /// <summary>
    ///    Beginning Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonBeginning")]
    ActionButtonBeginning = 167,

    /// <summary>
    ///    Return Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonReturn")]
    ActionButtonReturn = 168,

    /// <summary>
    ///    Document Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonDocument")]
    ActionButtonDocument = 169,

    /// <summary>
    ///    Sound Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonSound")]
    ActionButtonSound = 170,

    /// <summary>
    ///    Movie Button Shape.
    /// </summary> 
    [OpenXMLAttributeValue("actionButtonMovie")]
    ActionButtonMovie = 171,

    /// <summary>
    ///    Gear 6 Shape.
    /// </summary> "gear6".
    [OpenXMLAttributeValue("gear6")]
    Gear6 = 172,

    /// <summary>
    ///    Gear 9 Shape.
    /// </summary> "gear9".
    [OpenXMLAttributeValue("gear9")]
    Gear9 = 173,

    /// <summary>
    ///    Funnel Shape.
    /// </summary> 
    [OpenXMLAttributeValue("funnel")]
    Funnel = 174,

    /// <summary>
    ///    Plus Math Shape.
    /// </summary> 
    [OpenXMLAttributeValue("mathPlus")]
    MathPlus = 175,

    /// <summary>
    ///    Minus Math Shape.
    /// </summary> 
    [OpenXMLAttributeValue("mathMinus")]
    MathMinus = 176,

    /// <summary>
    ///    Multiply Math Shape.
    /// </summary> 
    [OpenXMLAttributeValue("mathMultiply")]
    MathMultiply = 177,

    /// <summary>
    ///    Divide Math Shape.
    /// </summary> 
    [OpenXMLAttributeValue("mathDivide")]
    MathDivide = 178,

    /// <summary>
    ///    Equal Math Shape.
    /// </summary> 
    [OpenXMLAttributeValue("mathEqual")]
    MathEqual = 179,

    /// <summary>
    ///    Not Equal Math Shape.
    /// </summary> 
    [OpenXMLAttributeValue("mathNotEqual")]
    MathNotEqual = 180,

    /// <summary>
    ///    Corner Tabs Shape.
    /// </summary> 
    [OpenXMLAttributeValue("cornerTabs")]
    CornerTabs = 181,

    /// <summary>
    ///    Square Tabs Shape.
    /// </summary> 
    [OpenXMLAttributeValue("squareTabs")]
    SquareTabs = 182,

    /// <summary>
    ///    Plaque Tabs Shape.
    /// </summary> 
    [OpenXMLAttributeValue("plaqueTabs")]
    PlaqueTabs = 183,

    /// <summary>
    ///    Chart X Shape.
    /// </summary> 
    [OpenXMLAttributeValue("chartX")]
    ChartX = 184,

    /// <summary>
    ///    Chart Star Shape.
    /// </summary> 
    [OpenXMLAttributeValue("chartStar")]
    ChartStar = 185,

    /// <summary>
    ///    Chart Plus Shape.
    /// </summary> 
    [OpenXMLAttributeValue("chartPlus")]
    ChartPlus = 186,
  }

}

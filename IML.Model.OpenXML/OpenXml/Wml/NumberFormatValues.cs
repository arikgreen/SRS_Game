using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("NumberFormat")]
  public enum NumberFormatValues
  {
    [EnumString("decimal")]
    Decimal = 0,
    [EnumString("upperRoman")]
    UpperRoman = 1,
    [EnumString("lowerRoman")]
    LowerRoman = 2,
    [EnumString("upperLetter")]
    UpperLetter = 3,
    [EnumString("lowerLetter")]
    LowerLetter = 4,
    [EnumString("ordinal")]
    Ordinal = 5,
    [EnumString("cardinalText")]
    CardinalText = 6,
    [EnumString("ordinalText")]
    OrdinalText = 7,
    [EnumString("hex")]
    Hex = 8,
    [EnumString("chicago")]
    Chicago = 9,
    [EnumString("ideographDigital")]
    IdeographDigital = 10,
    [EnumString("japaneseCounting")]
    JapaneseCounting = 11,
    [EnumString("aiueo")]
    Aiueo = 12,
    [EnumString("iroha")]
    Iroha = 13,
    [EnumString("decimalFullWidth")]
    DecimalFullWidth = 14,
    [EnumString("decimalHalfWidth")]
    DecimalHalfWidth = 15,
    [EnumString("japaneseLegal")]
    JapaneseLegal = 16,
    [EnumString("japaneseDigitalTenThousand")]
    JapaneseDigitalTenThousand = 17,
    [EnumString("decimalEnclosedCircle")]
    DecimalEnclosedCircle = 18,
    [EnumString("decimalFullWidth2")]
    DecimalFullWidth2 = 19,
    [EnumString("aiueoFullWidth")]
    AiueoFullWidth = 20,
    [EnumString("irohaFullWidth")]
    IrohaFullWidth = 21,
    [EnumString("decimalZero")]
    DecimalZero = 22,
    [EnumString("bullet")]
    Bullet = 23,
    [EnumString("ganada")]
    Ganada = 24,
    [EnumString("chosung")]
    Chosung = 25,
    [EnumString("decimalEnclosedFullstop")]
    DecimalEnclosedFullstop = 26,
    [EnumString("decimalEnclosedParen")]
    DecimalEnclosedParen = 27,
    [EnumString("decimalEnclosedCircleChinese")]
    DecimalEnclosedCircleChinese = 28,
    [EnumString("ideographEnclosedCircle")]
    IdeographEnclosedCircle = 29,
    [EnumString("ideographTraditional")]
    IdeographTraditional = 30,
    [EnumString("ideographZodiac")]
    IdeographZodiac = 31,
    [EnumString("ideographZodiacTraditional")]
    IdeographZodiacTraditional = 32,
    [EnumString("taiwaneseCounting")]
    TaiwaneseCounting = 33,
    [EnumString("ideographLegalTraditional")]
    IdeographLegalTraditional = 34,
    [EnumString("taiwaneseCountingThousand")]
    TaiwaneseCountingThousand = 35,
    [EnumString("taiwaneseDigital")]
    TaiwaneseDigital = 36,
    [EnumString("chineseCounting")]
    ChineseCounting = 37,
    [EnumString("chineseLegalSimplified")]
    ChineseLegalSimplified = 38,
    [EnumString("chineseCountingThousand")]
    ChineseCountingThousand = 39,
    [EnumString("koreanDigital")]
    KoreanDigital = 40,
    [EnumString("koreanCounting")]
    KoreanCounting = 41,
    [EnumString("koreanLegal")]
    KoreanLegal = 42,
    [EnumString("koreanDigital2")]
    KoreanDigital2 = 43,
    [EnumString("vietnameseCounting")]
    VietnameseCounting = 44,
    [EnumString("russianLower")]
    RussianLower = 45,
    [EnumString("russianUpper")]
    RussianUpper = 46,
    [EnumString("none")]
    None = 47,
    [EnumString("numberInDash")]
    NumberInDash = 48,
    [EnumString("hebrew1")]
    Hebrew1 = 49,
    [EnumString("hebrew2")]
    Hebrew2 = 50,
    [EnumString("arabicAlpha")]
    ArabicAlpha = 51,
    [EnumString("arabicAbjad")]
    ArabicAbjad = 52,
    [EnumString("hindiVowels")]
    HindiVowels = 53,
    [EnumString("hindiConsonants")]
    HindiConsonants = 54,
    [EnumString("hindiNumbers")]
    HindiNumbers = 55,
    [EnumString("hindiCounting")]
    HindiCounting = 56,
    [EnumString("thaiLetters")]
    ThaiLetters = 57,
    [EnumString("thaiNumbers")]
    ThaiNumbers = 58,
    [EnumString("thaiCounting")]
    ThaiCounting = 59,
    [EnumString("bahtText")]
    BahtText = 60,
    [EnumString("dollarText")]
    DollarText = 61,
    [EnumString("custom")]
    Custom = 62,
  }
}

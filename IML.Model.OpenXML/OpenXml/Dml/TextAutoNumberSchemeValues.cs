using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextAutonumberScheme")]
  public enum TextAutoNumberSchemeValues
  {
    [EnumString("alphaLcParenBoth")]
    AlphaLcParenBoth,
    [EnumString("alphaUcParenBoth")]
    AlphaUcParenBoth,
    [EnumString("alphaLcParenR")]
    AlphaLcParenR,
    [EnumString("alphaUcParenR")]
    AlphaUcParenR,
    [EnumString("alphaLcPeriod")]
    AlphaLcPeriod,
    [EnumString("alphaUcPeriod")]
    AlphaUcPeriod,
    [EnumString("arabicParenBoth")]
    ArabicParenBoth = 6,
    [EnumString("arabicParenR")]
    ArabicParenR = 7,
    [EnumString("arabicPeriod")]
    ArabicPeriod = 8,
    [EnumString("arabicPlain")]
    ArabicPlain = 9,
    [EnumString("romanLcParenBoth")]
    RomanLcParenBoth,
    [EnumString("romanUcParenBoth")]
    RomanUcParenBoth,
    [EnumString("romanLcParenR")]
    RomanLcParenR,
    [EnumString("romanUcParenR")]
    RomanUcParenR,
    [EnumString("romanLcPeriod")]
    RomanLcPeriod,
    [EnumString("romanUcPeriod")]
    RomanUcPeriod,
    [EnumString("circleNumDbPlain")]
    CircleNumDbPlain,
    [EnumString("circleNumWdBlackPlain")]
    CircleNumWdBlackPlain,
    [EnumString("circleNumWdWhitePlain")]
    CircleNumWdWhitePlain,
    [EnumString("arabicDbPeriod")]
    ArabicDbPeriod,
    [EnumString("arabicDbPlain")]
    ArabicDbPlain,
    [EnumString("ea1ChsPeriod")]
    Ea1ChsPeriod,
    [EnumString("ea1ChsPlain")]
    Ea1ChsPlain,
    [EnumString("ea1ChtPeriod")]
    Ea1ChtPeriod,
    [EnumString("ea1ChtPlain")]
    Ea1ChtPlain,
    [EnumString("ea1JpnChsDbPeriod")]
    Ea1JpnChsDbPeriod,
    [EnumString("ea1JpnKorPlain")]
    Ea1JpnKorPlain,
    [EnumString("ea1JpnKorPeriod")]
    Ea1JpnKorPeriod,
    [EnumString("arabic1Minus")]
    Arabic1Minus = 28,
    [EnumString("arabic2Minus")]
    Arabic2Minus = 29,
    [EnumString("hebrew2Minus")]
    Hebrew2Minus = 30,
    [EnumString("thaiAlphaPeriod")]
    ThaiAlphaPeriod = 31,
    [EnumString("thaiAlphaParenR")]
    ThaiAlphaParenR,
    [EnumString("thaiAlphaParenBoth")]
    ThaiAlphaParenBoth,
    [EnumString("thaiNumPeriod")]
    ThaiNumPeriod,
    [EnumString("thaiNumParenR")]
    ThaiNumParenR,
    [EnumString("thaiNumParenBoth")]
    ThaiNumParenBoth,
    [EnumString("hindiAlphaPeriod")]
    HindiAlphaPeriod = 37,
    [EnumString("hindiNumPeriod")]
    HindiNumPeriod = 38,
    [EnumString("hindiNumParenR")]
    HindiNumParenR,
    [EnumString("hindiAlpha1Period")]
    HindiAlpha1Period = 40,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextShapeType")]
  public enum TextShapeValues
  {
    [EnumString("textNoShape")]
    TextNoShape = 0,
    [EnumString("textPlain")]
    TextPlain = 1,
    [EnumString("textStop")]
    TextStop = 2,
    [EnumString("textTriangle")]
    TextTriangle = 3,
    [EnumString("textTriangleInverted")]
    TextTriangleInverted = 4,
    [EnumString("textChevron")]
    TextChevron = 5,
    [EnumString("textChevronInverted")]
    TextChevronInverted = 6,
    [EnumString("textRingInside")]
    TextRingInside = 7,
    [EnumString("textRingOutside")]
    TextRingOutside = 8,
    [EnumString("textArchUp")]
    TextArchUp = 9,
    [EnumString("textArchDown")]
    TextArchDown = 10,
    [EnumString("textCircle")]
    TextCircle = 11,
    [EnumString("textButton")]
    TextButton = 12,
    [EnumString("textArchUpPour")]
    TextArchUpPour = 13,
    [EnumString("textArchDownPour")]
    TextArchDownPour = 14,
    [EnumString("textCirclePour")]
    TextCirclePour = 15,
    [EnumString("textButtonPour")]
    TextButtonPour = 16,
    [EnumString("textCurveUp")]
    TextCurveUp = 17,
    [EnumString("textCurveDown")]
    TextCurveDown = 18,
    [EnumString("textCanUp")]
    TextCanUp = 19,
    [EnumString("textCanDown")]
    TextCanDown = 20,
    [EnumString("textWave1")]
    TextWave1 = 21,
    [EnumString("textWave2")]
    TextWave2 = 22,
    [EnumString("textDoubleWave1")]
    TextDoubleWave1 = 23,
    [EnumString("textWave4")]
    TextWave4 = 24,
    [EnumString("textInflate")]
    TextInflate = 25,
    [EnumString("textDeflate")]
    TextDeflate = 26,
    [EnumString("textInflateBottom")]
    TextInflateBottom = 27,
    [EnumString("textDeflateBottom")]
    TextDeflateBottom = 28,
    [EnumString("textInflateTop")]
    TextInflateTop = 29,
    [EnumString("textDeflateTop")]
    TextDeflateTop = 30,
    [EnumString("textDeflateInflate")]
    TextDeflateInflate = 31,
    [EnumString("textDeflateInflateDeflate")]
    TextDeflateInflateDeflate = 32,
    [EnumString("textFadeRight")]
    TextFadeRight = 33,
    [EnumString("textFadeLeft")]
    TextFadeLeft = 34,
    [EnumString("textFadeUp")]
    TextFadeUp = 35,
    [EnumString("textFadeDown")]
    TextFadeDown = 36,
    [EnumString("textSlantUp")]
    TextSlantUp = 37,
    [EnumString("textSlantDown")]
    TextSlantDown = 38,
    [EnumString("textCascadeUp")]
    TextCascadeUp = 39,
    [EnumString("textCascadeDown")]
    TextCascadeDown = 40,
  }
}

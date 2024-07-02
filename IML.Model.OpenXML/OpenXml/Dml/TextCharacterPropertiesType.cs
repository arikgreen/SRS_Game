using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("textCharacterProperties")]
  [Alias("TextCharacterProperties")]
  public class TextCharacterPropertiesType
  {
    [Tag("boolean")]
    Boolean Kumimoji{ get; set; }

    [Tag("lang")]
    LangValue Lang{ get; set; }

    [Tag("lang")]
    LangValue AltLang{ get; set; }

    [Tag("textFontSize")]
    TextFontSizeValue Sz{ get; set; }

    [Tag("boolean")]
    Boolean B{ get; set; }

    [Tag("boolean")]
    Boolean I{ get; set; }

    [Tag("textUnderlineType")]
    TextUnderlineValues U{ get; set; }

    [Tag("textStrikeType")]
    TextStrikeValues Strike{ get; set; }

    [Tag("textNonNegativePoint")]
    TextNonNegativePointValue Kern{ get; set; }

    [Tag("textCapsType")]
    TextCapsValues Cap{ get; set; }

    [Tag("textPoint")]
    TextPointValue Spc{ get; set; }

    [Tag("boolean")]
    Boolean NormalizeH{ get; set; }

    [Tag("percentage")]
    PercentageValue Baseline{ get; set; }

    [Tag("boolean")]
    Boolean NoProof{ get; set; }

    [Tag("boolean")]
    Boolean Dirty{ get; set; }

    [Tag("boolean")]
    Boolean Err{ get; set; }

    [Tag("boolean")]
    Boolean SmtClean{ get; set; }

    [Tag("unsignedInt")]
    UInt32 SmtId{ get; set; }

    [Tag("string")]
    String Bmk{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("textFont")]
  [Alias("TextFont")]
  public class TextFontType
  {
    [Tag("textTypeface")]
    TextTypefaceValue Typeface{ get; set; }

    [Tag("panose")]
    PanoseValue Panose{ get; set; }

    [Tag("pitchFamily")]
    PitchFamilyValue PitchFamily{ get; set; }

    [Tag("byte")]
    SByte Charset{ get; set; }

  }
}

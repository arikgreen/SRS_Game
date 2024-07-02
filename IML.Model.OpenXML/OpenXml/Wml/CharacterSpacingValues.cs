using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("CharacterSpacing")]
  public enum CharacterSpacingValues
  {
    [EnumString("doNotCompress")]
    DoNotCompress = 0,
    [EnumString("compressPunctuation")]
    CompressPunctuation = 1,
    [EnumString("compressPunctuationAndJapaneseKana")]
    CompressPunctuationAndJapaneseKana = 2,
  }
}

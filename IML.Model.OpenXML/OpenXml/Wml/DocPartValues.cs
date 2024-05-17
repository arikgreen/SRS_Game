using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Alias("DocPartType")]
  public enum DocPartValues
  {
    [EnumString("none")]
    None = 0,
    [EnumString("normal")]
    Normal = 1,
    [EnumString("autoExp")]
    AutoExp = 2,
    [EnumString("toolbar")]
    Toolbar = 3,
    [EnumString("speller")]
    Speller = 4,
    [EnumString("formFld")]
    FormFld,
    [EnumString("bbPlcHdr")]
    BbPlcHdr,
  }
}

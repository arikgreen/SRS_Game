using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("OnOffStyleType")]
  public enum BooleanStyleValues
  {
    [EnumString("on")]
    On = 0,
    [EnumString("off")]
    Off = 1,
    [EnumString("def")]
    Def,
  }
}

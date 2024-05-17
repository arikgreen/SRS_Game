using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Alias("TextStrikeType")]
  public enum TextStrikeValues
  {
    [EnumString("noStrike")]
    NoStrike = 0,
    [EnumString("sngStrike")]
    SngStrike,
    [EnumString("dblStrike")]
    DblStrike,
  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("patternFillProperties")]
  [Alias("PatternFillProperties")]
  public class MasterColorMapping
  {
    [Tag("presetPatternVal")]
    PresetPatternValues Prst{ get; set; }

  }
}

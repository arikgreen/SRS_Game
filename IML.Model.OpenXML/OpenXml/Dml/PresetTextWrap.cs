using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("textTabStop")]
  [Alias("TextTabStop")]
  public class PresetTextWrap
  {
    [Tag("coordinate32")]
    Coordinate32Value Pos{ get; set; }

    [Tag("textTabAlignType")]
    TextTabAlignmentValues Algn{ get; set; }

  }
}

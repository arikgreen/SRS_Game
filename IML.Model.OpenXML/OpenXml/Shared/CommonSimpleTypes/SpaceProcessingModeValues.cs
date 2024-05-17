using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Alias("VerticalAlignRun")]
  public enum SpaceProcessingModeValues
  {
    [EnumString("baseline")]
    Baseline,
    [EnumString("superscript")]
    Superscript,
    [EnumString("subscript")]
    Subscript,
  }
}

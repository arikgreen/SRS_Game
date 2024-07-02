using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("colorMapping")]
  [Alias("ColorMapping")]
  public class ColorMappingType
  {
    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Bg1{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Tx1{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Bg2{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Tx2{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Accent1{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Accent2{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Accent3{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Accent4{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Accent5{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Accent6{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues Hlink{ get; set; }

    [Tag("colorSchemeIndex")]
    ColorSchemeIndexValues FolHlink{ get; set; }

  }
}

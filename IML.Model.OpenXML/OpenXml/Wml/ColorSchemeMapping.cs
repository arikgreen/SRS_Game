using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("colorSchemeMapping")]
  [Alias("ColorSchemeMapping")]
  public class ColorSchemeMapping
  {
    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Bg1{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues T1{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Bg2{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues T2{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Accent1{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Accent2{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Accent3{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Accent4{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Accent5{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Accent6{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues Hyperlink{ get; set; }

    [Tag("wmlColorSchemeIndex")]
    ColorSchemeIndexValues FollowedHyperlink{ get; set; }

  }
}

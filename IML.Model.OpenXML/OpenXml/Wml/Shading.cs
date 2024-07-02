using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("shd")]
  [Alias("Shd")]
  public class Shading
  {
    [Tag("shd")]
    ShadingPatternValues Val{ get; set; }

    [Tag("hexColor")]
    HexColorValue Color{ get; set; }

    [Tag("themeColor")]
    ThemeColorValues ThemeColor{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeTint{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeShade{ get; set; }

    [Tag("hexColor")]
    HexColorValue Fill{ get; set; }

    [Tag("themeColor")]
    ThemeColorValues ThemeFill{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeFillTint{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeFillShade{ get; set; }

  }
}

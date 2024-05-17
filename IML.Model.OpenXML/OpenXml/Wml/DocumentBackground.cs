using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("background")]
  [Alias("Background")]
  public class DocumentBackground
  {
    [Tag("hexColor")]
    HexColorValue Color{ get; set; }

    [Tag("themeColor")]
    ThemeColorValues ThemeColor{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeTint{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeShade{ get; set; }

  }
}

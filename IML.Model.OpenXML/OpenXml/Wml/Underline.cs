using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("underline")]
  [Alias("Underline")]
  public class Underline
  {
    [Tag("underline")]
    UnderlineValues Val{ get; set; }

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

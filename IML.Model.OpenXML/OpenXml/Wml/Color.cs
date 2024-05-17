using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("color")]
  [Alias("Color")]
  public class Color
  {
    [Tag("hexColor")]
    HexColorValue Val{ get; set; }

    [Tag("themeColor")]
    ThemeColorValues ThemeColor{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeTint{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeShade{ get; set; }

  }
}

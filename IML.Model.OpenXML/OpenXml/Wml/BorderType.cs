using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("border")]
  [Alias("Border")]
  public class BorderType
  {
    [Tag("border")]
    BorderValues Val{ get; set; }

    [Tag("hexColor")]
    HexColorValue Color{ get; set; }

    [Tag("themeColor")]
    ThemeColorValues ThemeColor{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeTint{ get; set; }

    [Tag("ucharHexNumber")]
    UcharHexNumberValue ThemeShade{ get; set; }

    [Tag("eighthPointMeasure")]
    EighthPointMeasureValue Sz{ get; set; }

    [Tag("pointMeasure")]
    PointMeasureValue Space{ get; set; }

    [Tag("onOff")]
    OnOffValue Shadow{ get; set; }

    [Tag("onOff")]
    OnOffValue Frame{ get; set; }

  }
}

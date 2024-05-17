using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("fonts")]
  [Alias("Fonts")]
  public class Fonts
  {
    [Tag("hint")]
    FontTypeHintValues Hint{ get; set; }

    [Tag("string")]
    String Ascii{ get; set; }

    [Tag("string")]
    String HAnsi{ get; set; }

    [Tag("string")]
    String EastAsia{ get; set; }

    [Tag("string")]
    String Cs{ get; set; }

    [Tag("theme")]
    ThemeFontValues AsciiTheme{ get; set; }

    [Tag("theme")]
    ThemeFontValues HAnsiTheme{ get; set; }

    [Tag("theme")]
    ThemeFontValues EastAsiaTheme{ get; set; }

    [Tag("theme")]
    ThemeFontValues Cstheme{ get; set; }

  }
}

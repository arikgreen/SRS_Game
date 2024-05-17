using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("stylePaneFilter")]
  [Alias("StylePaneFilter")]
  public class StylePaneFormatFilter
  {
    [Tag("onOff")]
    OnOffValue AllStyles{ get; set; }

    [Tag("onOff")]
    OnOffValue CustomStyles{ get; set; }

    [Tag("onOff")]
    OnOffValue LatentStyles{ get; set; }

    [Tag("onOff")]
    OnOffValue StylesInUse{ get; set; }

    [Tag("onOff")]
    OnOffValue HeadingStyles{ get; set; }

    [Tag("onOff")]
    OnOffValue NumberingStyles{ get; set; }

    [Tag("onOff")]
    OnOffValue TableStyles{ get; set; }

    [Tag("onOff")]
    OnOffValue DirectFormattingOnRuns{ get; set; }

    [Tag("onOff")]
    OnOffValue DirectFormattingOnParagraphs{ get; set; }

    [Tag("onOff")]
    OnOffValue DirectFormattingOnNumbering{ get; set; }

    [Tag("onOff")]
    OnOffValue DirectFormattingOnTables{ get; set; }

    [Tag("onOff")]
    OnOffValue ClearFormatting{ get; set; }

    [Tag("onOff")]
    OnOffValue Top3HeadingStyles{ get; set; }

    [Tag("onOff")]
    OnOffValue VisibleStyles{ get; set; }

    [Tag("onOff")]
    OnOffValue AlternateStyleNames{ get; set; }

  }
}

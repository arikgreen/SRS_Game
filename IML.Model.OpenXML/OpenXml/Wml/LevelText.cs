using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("levelText")]
  [Alias("LevelText")]
  public class LevelText
  {
    [Tag("string")]
    String Val{ get; set; }

    [Tag("onOff")]
    OnOffValue Null{ get; set; }

  }
}

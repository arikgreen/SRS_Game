using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("style")]
  [Alias("Style")]
  public class Style
  {
    [Tag("styleType")]
    StyleValues Type{ get; set; }

    [Tag("string")]
    String StyleId{ get; set; }

    [Tag("onOff")]
    OnOffValue Default{ get; set; }

    [Tag("onOff")]
    OnOffValue CustomStyle{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("docPartName")]
  [Alias("DocPartName")]
  public class DocPartName
  {
    [Tag("string")]
    String Val{ get; set; }

    [Tag("onOff")]
    OnOffValue Decorated{ get; set; }

  }
}

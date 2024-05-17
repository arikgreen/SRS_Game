using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("docPartTypes")]
  [Alias("DocPartTypes")]
  public class DocPartTypes
  {
    [Tag("onOff")]
    OnOffValue All{ get; set; }

  }
}

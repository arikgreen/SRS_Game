using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("writeProtection")]
  [Alias("WriteProtection")]
  public class WriteProtection
  {
    [Tag("onOff")]
    OnOffValue Recommended{ get; set; }

  }
}

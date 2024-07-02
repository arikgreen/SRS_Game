using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("boolean")]
  [Alias("Boolean")]
  public class OnOff
  {
    [Tag("onOff")]
    OnOffValue Val{ get; set; }

  }
}

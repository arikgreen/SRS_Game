using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Dml
{
  [Tag("boolean")]
  [Alias("Boolean")]
  public class FOVAngle
  {
    [Tag("onOff")]
    OnOffValue Val{ get; set; }

  }
}

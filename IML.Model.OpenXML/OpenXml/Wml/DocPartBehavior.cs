using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("docPartBehavior")]
  [Alias("DocPartBehavior")]
  public class DocPartBehavior
  {
    [Tag("docPartBehavior")]
    DocPartBehaviorValues Val{ get; set; }

  }
}

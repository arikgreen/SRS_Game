using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Wml
{
  [Tag("ednPos")]
  [Alias("EdnPos")]
  public class EdnPos
  {
    [Tag("ednPos")]
    EndnotePositionValues Val{ get; set; }

  }
}

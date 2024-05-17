using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("oMathJc")]
  [Alias("OMathJc")]
  public class Jc
  {
    [Tag("jc")]
    JustificationValues Val{ get; set; }

  }
}

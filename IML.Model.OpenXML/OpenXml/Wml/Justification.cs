using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("jc")]
  [Alias("Jc")]
  public class Justification
  {
    [Tag("jc")]
    JustificationValues Val{ get; set; }

  }
}

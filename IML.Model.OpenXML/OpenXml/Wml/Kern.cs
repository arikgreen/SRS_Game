using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("perm")]
  [Alias("Perm")]
  public class Kern
  {
    [Tag("string")]
    String Id{ get; set; }

    [Tag("displacedByCustomXml")]
    DisplacedByCustomXmlValues DisplacedByCustomXml{ get; set; }

  }
}

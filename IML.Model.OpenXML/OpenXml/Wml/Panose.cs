using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("panose")]
  [Alias("Panose")]
  public class Panose
  {
    [Tag("panose")]
    PanoseValue Val{ get; set; }

  }
}

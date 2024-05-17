using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("forEach")]
  [Alias("ForEach")]
  public class ForEach
  {
    [Tag("string")]
    String Name{ get; set; }

    [Tag("string")]
    String Ref{ get; set; }

  }
}

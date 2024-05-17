using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("description")]
  [Alias("Description")]
  public class Description
  {
    [Tag("string")]
    String Lang{ get; set; }

    [Tag("string")]
    String Val{ get; set; }

  }
}

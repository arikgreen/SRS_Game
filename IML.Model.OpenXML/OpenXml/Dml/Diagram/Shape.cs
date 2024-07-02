using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("name")]
  [Alias("Name")]
  public class Shape
  {
    [Tag("string")]
    String Lang{ get; set; }

    [Tag("string")]
    String Val{ get; set; }

  }
}

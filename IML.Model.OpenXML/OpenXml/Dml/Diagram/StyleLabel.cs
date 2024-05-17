using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("styleLabel")]
  [Alias("StyleLabel")]
  public class StyleLabel
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}

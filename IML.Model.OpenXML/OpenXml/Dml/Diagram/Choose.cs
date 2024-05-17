using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("choose")]
  [Alias("Choose")]
  public class Choose
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}

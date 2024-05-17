using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("styleMatrix")]
  [Alias("StyleMatrix")]
  public class LineStyleList
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}

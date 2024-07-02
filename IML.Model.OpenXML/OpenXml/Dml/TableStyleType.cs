using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("tableStyle")]
  [Alias("TableStyle")]
  public class TableStyleType
  {
    [Tag("guid")]
    Guid StyleId{ get; set; }

    [Tag("string")]
    String StyleName{ get; set; }

  }
}

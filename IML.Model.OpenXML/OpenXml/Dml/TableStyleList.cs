using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("tableStyleList")]
  [Alias("TableStyleList")]
  public class TableStyleList
  {
    [Tag("guid")]
    Guid Def{ get; set; }

  }
}

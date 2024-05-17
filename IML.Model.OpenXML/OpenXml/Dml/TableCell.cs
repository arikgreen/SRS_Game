using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("tableCell")]
  [Alias("TableCell")]
  public class TableCell
  {
    [Tag("int")]
    Int32 RowSpan{ get; set; }

    [Tag("int")]
    Int32 GridSpan{ get; set; }

    [Tag("boolean")]
    Boolean HMerge{ get; set; }

    [Tag("boolean")]
    Boolean VMerge{ get; set; }

    [Tag("string")]
    String Id{ get; set; }

  }
}

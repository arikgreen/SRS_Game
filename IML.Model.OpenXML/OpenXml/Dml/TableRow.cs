using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("tableRow")]
  [Alias("TableRow")]
  public class TableRow
  {
    [Tag("coordinate")]
    CoordinateValue H{ get; set; }

  }
}

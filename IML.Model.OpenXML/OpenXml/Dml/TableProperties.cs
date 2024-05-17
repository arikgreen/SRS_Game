using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("tableProperties")]
  [Alias("TableProperties")]
  public class TableProperties
  {
    [Tag("boolean")]
    Boolean Rtl{ get; set; }

    [Tag("boolean")]
    Boolean FirstRow{ get; set; }

    [Tag("boolean")]
    Boolean FirstCol{ get; set; }

    [Tag("boolean")]
    Boolean LastRow{ get; set; }

    [Tag("boolean")]
    Boolean LastCol{ get; set; }

    [Tag("boolean")]
    Boolean BandRow{ get; set; }

    [Tag("boolean")]
    Boolean BandCol{ get; set; }

  }
}

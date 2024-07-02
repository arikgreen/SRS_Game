using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("tableCol")]
  [Alias("TableCol")]
  public class LastColumn
  {
    [Tag("coordinate")]
    CoordinateValue W{ get; set; }

  }
}

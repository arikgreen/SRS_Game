using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("tblGridCol")]
  [Alias("TblGridCol")]
  public class GridColumn
  {
    [Tag("twipsMeasure")]
    TwipsMeasureValue W{ get; set; }

  }
}

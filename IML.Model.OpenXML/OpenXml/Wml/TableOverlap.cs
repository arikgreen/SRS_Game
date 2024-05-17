using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("tblOverlap")]
  [Alias("TblOverlap")]
  public class TableOverlap
  {
    [Tag("tblOverlap")]
    TableOverlapValues Val{ get; set; }

  }
}

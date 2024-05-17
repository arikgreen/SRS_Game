using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("tblLayoutType")]
  [Alias("TblLayoutType")]
  public class TableLayout
  {
    [Tag("tblLayoutType")]
    TableLayoutValues Type{ get; set; }

  }
}

using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("tblStylePr")]
  [Alias("TblStylePr")]
  public class TableStyleProperties
  {
    [Tag("tblStyleOverrideType")]
    TableStyleOverrideValues Type{ get; set; }

  }
}

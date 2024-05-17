using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Charts
{
  [Tag("grouping")]
  [Alias("Grouping")]
  public class Grouping
  {
    [Tag("grouping")]
    GroupingValues Val{ get; set; }

  }
}

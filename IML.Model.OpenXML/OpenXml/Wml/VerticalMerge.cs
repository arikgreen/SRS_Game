using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("vMerge")]
  [Alias("VMerge")]
  public class VerticalMerge
  {
    [Tag("merge")]
    MergedCellValues Val{ get; set; }

  }
}

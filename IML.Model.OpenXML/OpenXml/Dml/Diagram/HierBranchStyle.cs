using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml.Dml.Diagram
{
  [Tag("hierBranchStyle")]
  [Alias("HierBranchStyle")]
  public class HierBranchStyle
  {
    [Tag("hierBranchStyle")]
    HierarchyBranchStyleValues Val{ get; set; }

  }
}

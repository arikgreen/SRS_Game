using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("childPref")]
  [Alias("ChildPref")]
  public class NodeCountValue
  {
    [Tag("nodeCount")]
    NodeCountValue Val{ get; set; }

  }
}

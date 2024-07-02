using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenXml
{
  [Tag("verticalAlignRun")]
  [Alias("VerticalAlignRun")]
  public class VerticalAlignRun
  {
    [Tag("verticalAlignRun")]
    SpaceProcessingModeValues Val{ get; set; }

  }
}

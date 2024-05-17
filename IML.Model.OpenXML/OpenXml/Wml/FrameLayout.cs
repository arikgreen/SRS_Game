using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("frameLayout")]
  [Alias("FrameLayout")]
  public class FrameLayout
  {
    [Tag("frameLayout")]
    FrameLayoutValues Val{ get; set; }

  }
}

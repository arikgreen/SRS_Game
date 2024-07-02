using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Tag("textboxInfo")]
  [Alias("TextboxInfo")]
  public class Extent
  {
    [Tag("unsignedShort")]
    UInt16 Id{ get; set; }

  }
}

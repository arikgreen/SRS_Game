using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml
{
  [Tag("xAlign")]
  [Alias("XAlign")]
  public class XAlign
  {
    [Tag("xAlign")]
    FileFormatVersions Val{ get; set; }

  }
}

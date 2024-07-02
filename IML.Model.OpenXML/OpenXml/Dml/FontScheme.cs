using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("fontScheme")]
  [Alias("FontScheme")]
  public class FontScheme
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}

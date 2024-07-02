using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Wordprocessing
{
  [Tag("font")]
  [Alias("Font")]
  public class Font
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}

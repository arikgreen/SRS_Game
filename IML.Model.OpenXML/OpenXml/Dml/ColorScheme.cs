using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("colorScheme")]
  [Alias("ColorScheme")]
  public class ColorScheme
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}

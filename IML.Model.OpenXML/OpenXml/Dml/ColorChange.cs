using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("colorChangeEffect")]
  [Alias("ColorChangeEffect")]
  public class ColorChange
  {
    [Tag("boolean")]
    Boolean UseA{ get; set; }

  }
}

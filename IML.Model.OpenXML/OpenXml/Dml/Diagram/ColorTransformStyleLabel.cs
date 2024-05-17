using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("cTStyleLabel")]
  [Alias("CTStyleLabel")]
  public class ColorTransformStyleLabel
  {
    [Tag("string")]
    String Name{ get; set; }

  }
}

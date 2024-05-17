using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing
{
  [Tag("flatText")]
  [Alias("FlatText")]
  public class FlatText
  {
    [Tag("coordinate")]
    CoordinateValue Z{ get; set; }

  }
}

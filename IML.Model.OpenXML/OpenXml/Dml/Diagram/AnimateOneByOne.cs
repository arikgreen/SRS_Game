using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Diagrams
{
  [Tag("animOne")]
  [Alias("AnimOne")]
  public class AnimateOneByOne
  {
    [Tag("animOneStr")]
    AnimateOneByOneValues Val{ get; set; }

  }
}

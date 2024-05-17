using OpenXml.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentFormat.OpenXml.Drawing.Wordprocessing
{
  [Tag("posV")]
  [Alias("PosV")]
  public class DocProperties
  {
    [Tag("relFromV")]
    VerticalRelativePositionValues RelativeFrom{ get; set; }

  }
}
